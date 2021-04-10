using System;
using System.Collections.Generic;
using System.Text;
using Athena.Data.Books;

namespace Athena.Data.PublishingHouses {
    public class PublishingHouseView {
        public Guid Id { get; set; }
        public string PublisherName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}