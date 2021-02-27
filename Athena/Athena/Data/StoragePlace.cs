using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athena.Data.Books;

namespace Athena.Data {
    public class StoragePlace {
        public Guid Id { get; set; }
        public string StoragePlaceName { get; set; }
        public string Comment { get; set; }

        public  ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return StoragePlaceName;
        }
    }
}