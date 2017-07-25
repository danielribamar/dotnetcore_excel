using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VolvoCleaner.Web.Frontend.Models
{
    public class FileModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalUrl { get; set; }
        public string ProcessedUrl { get; set; }
        public string LogUrl { get; set; }
        public int TypeId { get; set; }
        public DateTime CreatedDate { get; set; }

        public FileTypeModel Type { get; set; }
    }
}
