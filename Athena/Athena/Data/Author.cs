using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Athena.Data {
    public class Author {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new ObservableCollection<Book>();
    }
}