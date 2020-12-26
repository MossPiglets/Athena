using System;
using System.Collections.Generic;
using System.Text;

namespace Athena.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public Series Series { get; set; }
        public List<Categories> Category { get; set; }
        public PublishingHouse Publisher { get; set; }
        public DateTime PublishmentYear { get; set; }
        public Language Language { get; set; }
        public string ISBN { get; set; }
        public StoragePlace StoragePlace { get; set; }
        public string Comment { get; set; }
        public Borrowing Borrowing { get; set; }
    }
}
