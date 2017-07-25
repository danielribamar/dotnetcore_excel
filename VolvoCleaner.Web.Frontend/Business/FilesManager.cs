using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VolvoCleaner.Web.Frontend.Data;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Business
{
    public static class FilesManager
    {
        public async static Task Insert(IEnumerable<FileModel> model)
        {
            using (var context = new DatabaseContext())
            {
                foreach (var file in model)
                {
                    await context.Files.AddAsync(file);
                }

                await context.SaveChangesAsync();
            }
        }

        public async static Task<IEnumerable<FileModel>> Get()
        {
            using (var context = new DatabaseContext())
            {
                var files = await context.Files.ToListAsync();
                return files;
            }
        }

        public async static Task<FileModel> GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                var file = await context.Files.Include(p => p.Type).SingleOrDefaultAsync(p => p.Id == id);
                return file;
            }
        }

        public static NameGenderModel GetGenderModel(string filePath)
        {
            var model = new NameGenderModel();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    model = JsonConvert.DeserializeObject<NameGenderModel>(json);
                }
            }
            return model;
        }
    }
}
