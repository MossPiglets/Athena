using System;
using System.IO;

namespace AthenaTests.Helpers.Data
{
    public class TestExcelData {
        //List
        //public string FilePath = $"{Path.GetTempFileName()}";
        public string FileName = $"TestExcel_{Guid.NewGuid()}";
        public string WorksheetCatalog = "Catalog";
        public string WorksheetCategories = "Categories";
        public string WorksheetStoragePlaces = "StoragePlaces"; 
        
        // Tutaj powinna być List<CatalogTestData>
        // inne też w listach ziomek :)

        // tutaj do klasy to wszystko np. CatalogTestData
        public string Title = "Alibi";
        public string Author => $"{AuthorFirstName} {AuthorLastName}";
        public string AuthorFirstName = "Ryszard";
        public string AuthorLastName = "Szczerba";
        public string Series = "Ewa wzywa 07 - 56";
        public string PublishingHouse = "ISKRY";
        public string Year = "1973";
        public string Town = "Warszawa";
        public string ISBN = "978-83-246-2209-2";
        public string Language = "PL";
        public string StoragePlace = "I";
        public string Comment = "Pęknięty grzbiet";

        // też klasa CategoriesTestData
        public string Colour = "zielony";
        public string Category = "Album";

        // StoragePlacesTestData
        public string BoxNumber = "IV";
        public string BoxDescription = "Kryminał - duże i płaskie białe pudło";
    }
}
