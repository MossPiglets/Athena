using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Athena.Data {
    public class Category {
        public CategoryName Name { get; set; }
        public ICollection<Book> Books { get; set; } 
    }
}