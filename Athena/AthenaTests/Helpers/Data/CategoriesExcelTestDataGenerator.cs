using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaTests.Helpers.Data {
    public class CategoriesExcelTestDataGenerator {
        public static List<CategoriesExcelTestData> Generate() => new List<CategoriesExcelTestData>() {
            new CategoriesExcelTestData() {
                Colour = "Green",
                Category = "Kryminał"
            },
            new CategoriesExcelTestData() {
                Colour = "Red",
                Category = "Romans"
            }
        };
    }
}