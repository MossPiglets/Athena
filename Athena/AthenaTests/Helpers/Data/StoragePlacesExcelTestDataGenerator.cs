using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaTests.Helpers.Data
{
    class StoragePlacesExcelTestDataGenerator
    {
        public static List<StoragePlacesExcelTestData> Generate () => new List<StoragePlacesExcelTestData>() {
            new StoragePlacesExcelTestData() {
                BoxSign = "V",
                Description = "Małe, czerwone pudło po sokowirówce"
            },
            new StoragePlacesExcelTestData() {
                BoxSign = "III",
                Description = "WIelki, typowy karton"
            }
        };
    }
}
