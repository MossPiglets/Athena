using System;
using System.Collections.Generic;
using System.Text;
using Athena.Data;

namespace AthenaTests.Helpers.Data {
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