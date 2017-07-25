using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Helpers
{
    public static class ExcelHelper
    {
        public static ExcelPackage CreateExcelPackage(ServiceModel[] model)
        {
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "Report";
            package.Workbook.Properties.Author = "Tribe";
            package.Workbook.Properties.Subject = "cleaned";
            package.Workbook.Properties.Keywords = "Volvo";

            var worksheet = package.Workbook.Worksheets.Add("processed");

            //First add the headers
            for (int index = 1; index < model.First().GetType().GetProperties().Count(); index++)
            {
                worksheet.Cells[1, index].Value = model.First().GetType().GetProperties()[index].Name;
            }

            //foreach (PropertyInfo propertyInfo in model.GetType().GetProperties().Count())
            //{
            //    worksheet.Cells[1, 1].Value = "Column1";
            //}

            //Add values
            var numberformat = "#,##0";
            var dataCellStyleName = "TableNumber";
            var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberformat;

            for (int index = 1, row = 2; index < model.Count(); index++, row++)
            {
                worksheet.Cells[row, 1].Value = model[index].Filename;

                worksheet.Cells[row, 2].Value = model[index].TitleSalutation;

                worksheet.Cells[row, 3].Value = model[index].FirstName;

                worksheet.Cells[row, 4].Value = model[index].FamilyName;
                if (model[index].FirstName.ToString().Length + model[index].FamilyName.ToString().Length > 30)
                {
                    worksheet.Cells[row, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                    worksheet.Cells[row, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                }

                worksheet.Cells[row, 5].Value = model[index].Gender;

                worksheet.Cells[row, 6].Value = model[index].Language;

                worksheet.Cells[row, 7].Value = model[index].Address1;

                worksheet.Cells[row, 8].Value = model[index].Address2;

                worksheet.Cells[row, 9].Value = model[index].Address3;

                worksheet.Cells[row, 10].Value = model[index].Address4;

                worksheet.Cells[row, 11].Value = model[index].Postcode;

                worksheet.Cells[row, 12].Value = model[index].TownCity;

                worksheet.Cells[row, 13].Value = model[index].Email;

                worksheet.Cells[row, 14].Value = model[index].MobileNumber;

                worksheet.Cells[row, 15].Value = model[index].TelephoneNumber;

                worksheet.Cells[row, 16].Value = model[index].VIN;
                if (model[index].VIN.ToString().Length > 17)
                {
                    worksheet.Cells[row, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 16].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                }

                worksheet.Cells[row, 17].Value = model[index].EventDate;
                if (!ValuesHelper.HasValidDate(model[index].EventDate.ToString()))
                {
                    worksheet.Cells[row, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 17].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                }

                worksheet.Cells[row, 18].Value = model[index].DealerCode;

                worksheet.Cells[row, 19].Value = model[index].BusinessPrivate;

                worksheet.Cells[row, 20].Value = model[index].Company;

                worksheet.Cells[row, 21].Value = model[index].ServiceType;
                if (!ValuesHelper.HasValidServiceType(model[index].ServiceType.ToString()))
                {
                    worksheet.Cells[row, 21].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 21].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                }

                worksheet.Cells[row, 22].Value = model[index].SalesDate;
                if (!ValuesHelper.HasValidDate(model[index].SalesDate.ToString()))
                {
                    worksheet.Cells[row, 22].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, 22].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                }

                worksheet.Cells[row, 23].Value = model[index].Mileage;

                worksheet.Cells[row, 24].Value = model[index].EmailPref;

                worksheet.Cells[row, 25].Value = model[index].DirectMailPref;

                worksheet.Cells[row, 26].Value = model[index].PhonePref;

                worksheet.Cells[row, 27].Value = model[index].SMSPref;
            }

            // Add to table / Add summary row
            var tbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: model.Count() + 1, toColumn: 27), "Data");
            tbl.ShowHeader = false;
            tbl.ShowTotal = false;
            tbl.TableStyle = TableStyles.None;

            // AutoFitColumns
            worksheet.Cells[1, 1, model.Count() + 1, 27].AutoFitColumns();

            return package;
        }

        public static IEnumerable<ServiceModel> ProcessPackage(IEnumerable<ServiceModel> model)
        {
            foreach (var row in model.Skip(1))
            {
                foreach (PropertyInfo propertyInfo in row.GetType().GetProperties())
                {
                    switch (propertyInfo.Name)
                    {
                        case "Filename":
                            break;
                        case "TitleSalutation":
                            break;
                        case "FirstName":
                            break;
                        case "FamilyName":
                            break;
                        case "Gender":
                            break;
                        case "Language":
                            break;
                        case "Address1":
                            break;
                        case "Address2":
                            break;
                        case "Address3":
                            break;
                        case "Address4":
                            break;
                        case "Postcode":
                            break;
                        case "TownCity":
                            break;
                        case "Email":
                            break;
                        case "MobileNumber":
                            break;
                        case "TelephoneNumber":
                            break;
                        case "VIN":
                            break;
                        case "EventDate":
                            break;
                        case "DealerCode":
                            break;
                        case "BusinessPrivate":
                            break;
                        case "Company":
                            break;
                        case "ServiceType":
                            break;
                    }
                }
            }

            return model;
        }

        public static IEnumerable<ServiceModel> Read(FileInfo fileInfo)
        {
            var dataModels = new List<ServiceModel>();
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                for (int row = 1; row <= rowCount; row++)
                {
                    var rowModel = new ServiceModel(row);

                    rowModel.Filename = worksheet.Cells[row, 1].Text;
                    rowModel.TitleSalutation = worksheet.Cells[row, 2].Text;
                    rowModel.FirstName = worksheet.Cells[row, 3].Text;
                    rowModel.FamilyName = worksheet.Cells[row, 4].Text;
                    rowModel.Gender = worksheet.Cells[row, 5].Text;
                    rowModel.Language = worksheet.Cells[row, 6].Text;
                    rowModel.Address1 = worksheet.Cells[row, 7].Text;
                    rowModel.Address2 = worksheet.Cells[row, 8].Text;
                    rowModel.Address3 = worksheet.Cells[row, 9].Text;
                    rowModel.Address4 = worksheet.Cells[row, 10].Text;
                    rowModel.Postcode = worksheet.Cells[row, 11].Text;
                    rowModel.TownCity = worksheet.Cells[row, 12].Text;
                    rowModel.Email = worksheet.Cells[row, 13].Text;
                    rowModel.MobileNumber = worksheet.Cells[row, 14].Text;
                    rowModel.TelephoneNumber = worksheet.Cells[row, 15].Text;
                    rowModel.VIN = worksheet.Cells[row, 16].Text;
                    rowModel.EventDate = worksheet.Cells[row, 17].Text;
                    rowModel.DealerCode = worksheet.Cells[row, 18].Text;
                    rowModel.BusinessPrivate = worksheet.Cells[row, 19].Text;
                    rowModel.Company = worksheet.Cells[row, 20].Text;
                    rowModel.ServiceType = worksheet.Cells[row, 21].Text;
                    rowModel.SalesDate = worksheet.Cells[row, 22].Text;
                    rowModel.Mileage = worksheet.Cells[row, 23].Text;
                    rowModel.EmailPref = worksheet.Cells[row, 24].Text;
                    rowModel.DirectMailPref = worksheet.Cells[row, 25].Text;
                    rowModel.PhonePref = worksheet.Cells[row, 26].Text;
                    rowModel.SMSPref = worksheet.Cells[row, 27].Text;

                    dataModels.Add(rowModel);
                }
                return dataModels;
            }
        }
    }
}
