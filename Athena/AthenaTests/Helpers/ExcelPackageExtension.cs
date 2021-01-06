using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AthenaTests.Helpers.Data;
using OfficeOpenXml;

namespace AthenaTests.Helpers
{
    public static class ExcelPackageExtension
    {
        public static void CreateTestsExcel(this ExcelPackage package, TestExcelData data) {
            var worksheetCatalog = package.Workbook.Worksheets.Add(data.WorksheetCatalog);
            worksheetCatalog.Cells[1,1].Value = "Tytuł";
            worksheetCatalog.Cells[1,2].Value = "Autor";
            worksheetCatalog.Cells[1,3].Value = "Seria";
            worksheetCatalog.Cells[1,4].Value = "Wydawnictwo";
            worksheetCatalog.Cells[1,5].Value = "Rok";
            worksheetCatalog.Cells[1,6].Value = "Miejscowość";
            worksheetCatalog.Cells[1,7].Value = "ISBN";
            worksheetCatalog.Cells[1,8].Value = "Język";
            worksheetCatalog.Cells[1,9].Value = "Miejsce składowania";
            worksheetCatalog.Cells[1,10].Value = "Uwagi";

            worksheetCatalog.Cells[2,1].Value = data.Title;
            worksheetCatalog.Cells[2,2].Value = data.Author;
            worksheetCatalog.Cells[2,3].Value = data.Series;
            worksheetCatalog.Cells[2,4].Value = data.PublishingHouse;
            worksheetCatalog.Cells[2,5].Value = data.Year;
            worksheetCatalog.Cells[2,6].Value = data.Town;
            worksheetCatalog.Cells[2,7].Value = data.ISBN;
            worksheetCatalog.Cells[2,8].Value = data.Language;
            worksheetCatalog.Cells[2,9].Value = data.StoragePlace;
            worksheetCatalog.Cells[2,10].Value = data.Comment;

            var worksheetCategories = package.Workbook.Worksheets.Add(data.WorksheetCategories);
            worksheetCategories.Cells[1,1].Value = "Kolor";
            worksheetCategories.Cells[1,2].Value = "Kategoria";
            worksheetCategories.Cells[2,1].Value = data.Colour;
            worksheetCategories.Cells[2,2].Value = data.Category;

            var worksheetStoragePlaces = package.Workbook.Worksheets.Add(data.WorksheetStoragePlaces);
            worksheetStoragePlaces.Cells[1,1].Value = "Nr pudła";
            worksheetStoragePlaces.Cells[1, 2].Value = "Komentarz";
            worksheetStoragePlaces.Cells[2, 1].Value = data.BoxNumber;
            worksheetStoragePlaces.Cells[2, 2].Value = data.BoxDescription;

            package.SaveAs(new FileInfo(data.FilePath));
        }
    }
}
