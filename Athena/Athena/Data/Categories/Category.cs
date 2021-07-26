using System.Collections.Generic;
using Athena.Data.Books;

namespace Athena.Data.Categories {
    public class Category {
        public CategoryName Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}