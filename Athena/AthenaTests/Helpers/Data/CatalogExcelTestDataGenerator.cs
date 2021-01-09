using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaTests.Helpers.Data {
    public class CatalogExcelTestDataGenerator {
        public static List<CatalogExcelTestData> Generate() => new List<CatalogExcelTestData>() {
            new CatalogExcelTestData() {
                Title = "Alibi",
                AuthorFirstName = "Ryszard",
                AuthorLastName = "Szczerba",
                Series = "Ewa wzywa 07 - 56",
                PublishingHouse = "ISKRY",
                Year = "1973",
                Town = "Warszawa",
                ISBN = "978-83-246-2209-2",
                Language = "PL",
                StoragePlace = "I",
                Comment = "Pęknięty grzbiet"
            },
            new CatalogExcelTestData() {
                Title = "Igrzyska śmierci",
                AuthorFirstName = "Suzanne",
                AuthorLastName = "Collins",
                Series = "Igrzyska śmierci",
                PublishingHouse = "Media Rodzina",
                Year = "2012",
                Town = "Warszawa",
                ISBN = "978-83-255-4175-6",
                Language = "PL",
                StoragePlace = "IV",
                Comment = "Filmowe wydanie"
            }
        };
    }
}