using System;
using System.Collections.Generic;
using System.Text;

namespace Athena.Data
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublishmentYear { get; set; }
        public Language Language { get; set; }
        public string ISBN { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual Series Series { get; set; }
        public virtual PublishingHouse PublishingHouse { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual StoragePlace StoragePlace { get; set; }
        public virtual Borrowing Borrowing { get; set; }
    }
}
