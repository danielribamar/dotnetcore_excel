using System;
using System.Collections.Generic;
using System.Linq;
using VolvoCleaner.Web.Frontend.Data;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Business
{
    public static class FileTypesManager
    {
        public static IEnumerable<FileTypeModel> Get(Func<FileTypeModel, bool> filter)
        {
            using (var context = new DatabaseContext())
            {
                var types = context.FileTypes.Where(filter).ToList();
                return types;
            }
        }
    }
}
