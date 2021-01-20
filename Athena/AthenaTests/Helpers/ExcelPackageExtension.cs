using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using AthenaTests.Helpers.Data;
using AthenaTests.Helpers.Data.TestExcel;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace AthenaTests.Helpers {
    public static class ExcelPackageExtension {
        public static void CreateTestsExcel(this ExcelPackage package, TestExcelData data) {
            var worksheetCatalog = package.Workbook.Worksheets.Add(data.WorksheetCatalog);
            worksheetCatalog.Cells[1, 1].Value = "Tytuł";
            worksheetCatalog.Cells[1, 2].Value = "Autor";
            worksheetCatalog.Cells[1, 3].Value = "Seria";
            worksheetCatalog.Cells[1, 4].Value = "Wydawnictwo";
            worksheetCatalog.Cells[1, 5].Value = "Rok";
            worksheetCatalog.Cells[1, 6].Value = "Miejscowość";
            worksheetCatalog.Cells[1, 7].Value = "ISBN";
            worksheetCatalog.Cells[1, 8].Value = "Język";
            worksheetCatalog.Cells[1, 9].Value = "Miejsce składowania";
            worksheetCatalog.Cells[1, 10].Value = "Uwagi";

            for (int i = 0; i < data.CatalogTestsDataList.Count; i++) {
                var catalogRowData = data.CatalogTestsDataList[i];
                worksheetCatalog.Cells[i + 2, 1].Value = catalogRowData.Title;
                worksheetCatalog.Cells[i + 2, 2].Value = catalogRowData.Author;
                worksheetCatalog.Cells[i + 2, 3].Value = catalogRowData.Series;
                worksheetCatalog.Cells[i + 2, 4].Value = catalogRowData.PublishingHouse;
                worksheetCatalog.Cells[i + 2, 5].Value = catalogRowData.Year;
                worksheetCatalog.Cells[i + 2, 6].Value = catalogRowData.Town;
                worksheetCatalog.Cells[i + 2, 7].Value = catalogRowData.ISBN;
                worksheetCatalog.Cells[i + 2, 8].Value = catalogRowData.Language;
                worksheetCatalog.Cells[i + 2, 9].Value = catalogRowData.StoragePlace;
                worksheetCatalog.Cells[i + 2, 10].Value = catalogRowData.Comment;
                var color = System.Drawing.ColorTranslator.FromHtml(catalogRowData.ColorCode);
                worksheetCatalog.Cells[i + 2, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetCatalog.Cells[i + 2, 2].Style.Fill.BackgroundColor.SetColor(color);
            }


            var worksheetCategories = package.Workbook.Worksheets.Add(data.WorksheetCategories);
            worksheetCategories.Cells[1, 1].Value = "Kolor";
            worksheetCategories.Cells[1, 2].Value = "Kategoria";

            for (int i = 0; i < data.CategoryTestsDataList.Count; i++) {
                var categoryRowData = data.CategoryTestsDataList[i];
                worksheetCategories.Cells[i + 2, 1].Value = categoryRowData.Colour;
                worksheetCategories.Cells[i + 2, 2].Value = categoryRowData.Category;
                var color = System.Drawing.ColorTranslator.FromHtml(categoryRowData.ColourCode);
                worksheetCategories.Cells[i + 2, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheetCategories.Cells[i + 2, 1].Style.Fill.BackgroundColor.SetColor(color);
            }
            

            var worksheetStoragePlaces = package.Workbook.Worksheets.Add(data.WorksheetStoragePlaces);
            worksheetStoragePlaces.Cells[1, 1].Value = "Nr pudła";
            worksheetStoragePlaces.Cells[1, 2].Value = "Komentarz";

            for (int i = 0; i < data.StoragePlaceTestsDataList.Count; i++) {
                var storagePlaceRowData = data.StoragePlaceTestsDataList[i];
                worksheetStoragePlaces.Cells[i + 2, 1].Value = storagePlaceRowData.StoragePlaceName;
                worksheetStoragePlaces.Cells[i + 2, 2].Value = storagePlaceRowData.Description;
            }

            package.SaveAs(new FileInfo(data.FileName));
        }
    }
}