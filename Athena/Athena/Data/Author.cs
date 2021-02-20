using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athena.Data.Books;

namespace Athena.Data {
    public class Author {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                return LastName;
            else
                return $"{FirstName} {LastName}";
        }
    }

    
}