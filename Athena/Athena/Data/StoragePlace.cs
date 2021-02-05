using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Athena.Data {
    public class StoragePlace {
        public Guid Id { get; set; }
        public string StoragePlaceName { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public override string ToString()
        {
            return StoragePlaceName;
        }
    }
}