using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolvoCleaner.Web.Frontend.Models
{
    public class FileTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FileModel> Files { get; set; }
    }
}
