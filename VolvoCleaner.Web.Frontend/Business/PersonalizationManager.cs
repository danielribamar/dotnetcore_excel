using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Business
{
    public class PersonalizationManager
    {
        public static PersonalizationModel[] Read(FileInfo fileInfo)
        {
            var dataModels = new List<PersonalizationModel>();
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    var rowModel = new PersonalizationModel();

                    rowModel.Id = worksheet.Cells[row, 1].Text;
                    rowModel.FirstName = worksheet.Cells[row, 2].Text;
                    rowModel.LastName = worksheet.Cells[row, 3].Text;
                    rowModel.AdditionalName = worksheet.Cells[row, 4].Text;
                    rowModel.AdditionalSurname = worksheet.Cells[row, 5].Text;
                    rowModel.Gender = worksheet.Cells[row, 6].Text;
                    rowModel.ContactCreatedDate = worksheet.Cells[row, 7].Text;

                    dataModels.Add(rowModel);
                }
                return dataModels.ToArray();
            }
        }

        public static ExcelPackage Process(PersonalizationModel[] model, IHostingEnvironment env)
        {
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "Report";
            package.Workbook.Properties.Author = "Tribe";
            package.Workbook.Properties.Subject = "cleaned";
            package.Workbook.Properties.Keywords = "Volvo";

            var worksheet = package.Workbook.Worksheets.Add("processed");

            //Add headers
            worksheet.Cells[1, 1].Value = "CDB_ID";
            worksheet.Cells[1, 2].Value = "First Name";
            worksheet.Cells[1, 3].Value = "Last Name";
            worksheet.Cells[1, 4].Value = "Additional Name";
            worksheet.Cells[1, 5].Value = "Additional Surname";
            worksheet.Cells[1, 6].Value = "Gender";
            worksheet.Cells[1, 7].Value = "Contact Created Date";
            //Add values
            var numberformat = "#,##0";
            var dataCellStyleName = "TableNumber";
            var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberformat;

            for (int index = 1, row = 2; index < model.Count(); index++, row++)
            {
                worksheet.Cells[row, 1].Value = model[index].Id;
                worksheet.Cells[row, 2].Value = model[index].FirstName;
                if (string.IsNullOrEmpty(model[index].FirstName.ToString()))
                {
                    worksheet.Cells[row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 2].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }
                worksheet.Cells[row, 3].Value = model[index].LastName;
                if (string.IsNullOrEmpty(model[index].LastName.ToString()))
                {
                    worksheet.Cells[row, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 3].Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                }
                worksheet.Cells[row, 4].Value = model[index].AdditionalName;
                worksheet.Cells[row, 5].Value = model[index].AdditionalSurname;
                worksheet.Cells[row, 6].Value = model[index].Gender;
                worksheet.Cells[row, 7].Value = model[index].ContactCreatedDate;

            }

            // Add to table / Add summary row
            var tbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: model.Count() + 1, toColumn: 7), "Data");
            tbl.ShowHeader = true;
            tbl.ShowTotal = true;
            tbl.TableStyle = TableStyles.None;

            // AutoFitColumns
            worksheet.Cells[1, 1, model.Count() + 1, 7].AutoFitColumns();

            return package;
        }
    }
}
