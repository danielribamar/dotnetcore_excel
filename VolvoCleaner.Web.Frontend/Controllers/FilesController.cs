using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VolvoCleaner.Web.Frontend.Business;
using VolvoCleaner.Web.Frontend.Helpers;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Controllers
{
    public class FilesController : Controller
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _reportsFolder = "files";

        public FilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormCollection form)
        {
            var files = new List<FileModel>();
            var type = FileTypesManager.Get(p => p.Name.Equals(form["type"])).SingleOrDefault();

            foreach (var file in form.Files.Where(p => p.FileName.ToLowerInvariant().EndsWith(".xlsx")))
            {
                var fileName = $"{Guid.NewGuid().ToString("N")}_{file.FileName}";

                using (var fileStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, _reportsFolder, "uploaded", type.Name, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                files.Add(
                    new FileModel
                    {
                        CreatedDate = DateTime.Now,
                        LogUrl = "",
                        Name = fileName,
                        OriginalUrl = "download",
                        ProcessedUrl = "process",
                        TypeId = type.Id
                    });
            }

            await FilesManager.Insert(files);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Process(int id)
        {
            var file = await FilesManager.GetById(id);

            if (file == null)
            {
                return NotFound(id);
            }

            var fileInfo = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, _reportsFolder, "uploaded", file.Type.Name, file.Name));

            if (!fileInfo.Exists)
            {
                return NotFound(fileInfo.Directory);
            }

            ExcelPackage package;

            switch (file.Type.Name)
            {
                case "services":
                    var s_data = ServiceManager.Read(fileInfo);
                    package = ServiceManager.Process(s_data);
                    break;
                case "personalization":
                    var validationPath = Path.Combine(_hostingEnvironment.WebRootPath, "files", "validation", "namesgender.json");
                    ValuesHelper.namesList = FilesManager.GetGenderModel(validationPath); ;
                    var p_data = PersonalizationManager.Read(fileInfo);
                    package = PersonalizationManager.Process(p_data, _hostingEnvironment);
                    break;
                default:
                    package = null;
                    break;
            }

            using (package)
            {
                var processedFile = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, _reportsFolder, "processed", file.Type.Name, file.Name));
                package.SaveAs(processedFile);

                return File($"~/{_reportsFolder}/processed/{file.Type.Name}/{processedFile.Name}", XlsxContentType, processedFile.Name);
            }
        }

        public async Task<IActionResult> DownloadOriginal(int id)
        {
            var file = await FilesManager.GetById(id);

            if (file == null)
            {
                return NotFound(id);
            }
            return File($"~/{_reportsFolder}/{file.Type.Name}/{file.Name}", XlsxContentType, file.Name);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
