using System.Collections.Generic;

namespace AthenaTests.Helpers.Data.TestExcel
{
    class StoragePlacesExcelTestDataGenerator
    {
        public static List<StoragePlacesExcelTestData> Generate () => new List<StoragePlacesExcelTestData>() {
            new StoragePlacesExcelTestData() {
                StoragePlaceName = "V",
                Description = "Małe, czerwone pudło po sokowirówce"
            },
            new StoragePlacesExcelTestData() {
                StoragePlaceName = "III",
                Description = "Wielki, typowy karton"
            }
        };
    }
}
