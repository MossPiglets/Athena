using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace AthenaTests.Helpers.Data
{
    public class TestExcelData {

        public string FileName = $"TestExcel_{Guid.NewGuid()}";
        public string WorksheetCatalog = "Catalog";
        public string WorksheetCategories = "Categories";
        public string WorksheetStoragePlaces = "StoragePlaces"; 
        
        public List<CatalogExcelTestData> CatalogTestsDataList = CatalogExcelTestDataGenerator.Generate();

        public List<CategoriesExcelTestData> CategoryTestsDataList = CategoriesExcelTestDataGenerator.Generate();

        public List<StoragePlacesExcelTestData> StoragePlaceTestsDataList =
            StoragePlacesExcelTestDataGenerator.Generate();
    }
}
