using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;

namespace ExcelHelper.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _reportsFolder = "files";

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Upload()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormCollection form)
        {
            if (!form.Files.Any())
            {
                return BadRequest("no file in request");
            }

            var file = form.Files.FirstOrDefault();
            var fileName = $"{Guid.NewGuid().ToString("N")}_{file.FileName}";

            using (var fileStream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, _reportsFolder, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var fileInfo = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, _reportsFolder, fileName));

            if (!fileInfo.Exists)
            {
                return NotFound(fileInfo.Directory);
            }

            var rows = Helpers.ExcelHelper.Read(fileInfo);
            
            foreach(var row in rows)
            {
                //insert to database
            }

            return RedirectToAction("Upload");
        }
    }
}
