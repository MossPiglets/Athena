using System.Collections.Generic;
using Athena.Data;
using Athena.Data.Categories;

namespace AthenaTests.Helpers.Data.TestExcel {
    public class CategoriesExcelTestDataGenerator {
        public static List<CategoriesExcelTestData> Generate() => new List<CategoriesExcelTestData>() {
            new CategoriesExcelTestData() {
                Colour = "green",
                ColourCode = "#E8FCC8",
                Category = "Album",
                CategoryName = new Category {
                    Name = CategoryName.Album
                }
            },
            new CategoriesExcelTestData() {
                Colour = "red",
                ColourCode = "#ABABFF",
                Category = "Atlas",
                CategoryName = new Category {
                    Name = CategoryName.Atlas
                }
            }
        };
    }
}