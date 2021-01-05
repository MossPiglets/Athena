using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OfficeOpenXml;

namespace AthenaTests.Helpers
{
    public static class ExcelPackageExtension
    {
        public static void CreateTestsExcel(this ExcelPackage package, TestExcelData data) {
            var worksheet = package.Workbook.Worksheets.Add(data.FileName);
            worksheet.Cells[1,1].Value = "Tytuł";
            worksheet.Cells[1,2].Value = "Autor";
            worksheet.Cells[1,3].Value = "Seria";
            worksheet.Cells[1,4].Value = "Wydawnictwo";
            worksheet.Cells[1,5].Value = "Rok";
            worksheet.Cells[1,6].Value = "Miejscowość";
            worksheet.Cells[1,7].Value = "ISBN";
            worksheet.Cells[1,8].Value = "Język";
            worksheet.Cells[1,9].Value = "Miejsce składowania";
            worksheet.Cells[1,10].Value = "Uwagi";

            worksheet.Cells[2,1].Value = data.Title;
            worksheet.Cells[2,2].Value = data.Author;
            worksheet.Cells[2,3].Value = data.Series;
            worksheet.Cells[2,4].Value = data.PublishingHouse;
            worksheet.Cells[2,5].Value = data.Year;
            worksheet.Cells[2,6].Value = data.Town;
            worksheet.Cells[2,7].Value = data.ISBN;
            worksheet.Cells[2,8].Value = data.Language;
            worksheet.Cells[2,9].Value = data.StoragePlace;
            worksheet.Cells[2,10].Value = data.Comment;

            package.SaveAs(new FileInfo(data.FilePath));
        }
    }
}
