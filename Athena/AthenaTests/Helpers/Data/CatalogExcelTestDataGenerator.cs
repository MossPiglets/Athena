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
                Series = "Ewa wzywa 07 - 56 - tom 5",
                SeriesName = "Ewa wzywa 07 - 56",
                VolumeNumber = 5,
                PublishingHouse = "ISKRY",
                Year = "1973",
                Town = "Warszawa",
                ISBN = "978-83-246-2209-2",
                Language = "PL",
                StoragePlace = "biurko Anki",
                Comment = "Pęknięty grzbiet"
            },
            new CatalogExcelTestData() {
                Title = "Igrzyska śmierci",
                AuthorFirstName = "Suzanne",
                AuthorLastName = "Collins",
                Series = "Igrzyska śmierci - tom 1",
                SeriesName = "Igrzyska śmierci",
                VolumeNumber = 1,
                PublishingHouse = "Media Rodzina",
                Year = "2012",
                Town = "Warszawa",
                ISBN = "978-83-255-4175-6",
                Language = "PL",
                StoragePlace = "T5",
                Comment = "Filmowe wydanie"
            }
        };
    }
}