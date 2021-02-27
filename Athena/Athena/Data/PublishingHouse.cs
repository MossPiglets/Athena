using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Athena.Data.Books;

namespace Athena.Data {
    public class PublishingHouse {
        public Guid Id { get; set; }
        public string PublisherName { get; set; }
        public virtual ICollection<Book> Books { get; set; } 
    }
}