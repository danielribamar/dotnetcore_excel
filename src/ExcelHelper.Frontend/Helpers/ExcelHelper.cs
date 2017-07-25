using ExcelHelper.Frontend.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelHelper.Frontend.Helpers
{
    public class ExcelHelper
    {
        internal static Row[] Read(FileInfo fileInfo)
        {
            var dataModels = new List<Row>();
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    var rowModel = new Row();

                    rowModel.Name = worksheet.Cells[row, 1].Text;
                    rowModel.NRIC = worksheet.Cells[row, 2].Text;
                    rowModel.EmailAddress = worksheet.Cells[row, 3].Text;
                    rowModel.PhoneNumber = worksheet.Cells[row, 4].Text;
                    rowModel.DiplomaChoice1 = worksheet.Cells[row, 5].Text;
                    rowModel.DiplomaChoice2 = worksheet.Cells[row, 6].Text;
                    rowModel.DiplomaChoice3 = worksheet.Cells[row, 7].Text;
                    rowModel.DiplomaChoice4 = worksheet.Cells[row, 8].Text;
                    rowModel.Password = worksheet.Cells[row, 9].Text;

                    dataModels.Add(rowModel);
                }
                return dataModels.ToArray();
            }
        }
    }
}
