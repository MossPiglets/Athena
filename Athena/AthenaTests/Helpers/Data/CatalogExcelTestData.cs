using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaTests.Helpers.Data {
    public class CatalogExcelTestData {
        public string Title { get; set; }
        public string Author => $"{AuthorFirstName} {AuthorLastName}";
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string Series { get; set; }
        public string PublishingHouse { get; set; }
        public string Year { get; set; }
        public string Town { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string StoragePlace { get; set; }
        public string Comment { get; set; }
    }
}