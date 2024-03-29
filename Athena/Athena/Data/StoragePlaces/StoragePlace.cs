﻿using System;
using System.Collections.Generic;
using Athena.Data.Books;

namespace Athena.Data.StoragePlaces {
    public class StoragePlace {
        public Guid Id { get; set; }
        public string StoragePlaceName { get; set; }
        public string Comment { get; set; }

        public ICollection<Book> Books { get; set; }

        public override string ToString() {
            return StoragePlaceName;
        }
    }
}