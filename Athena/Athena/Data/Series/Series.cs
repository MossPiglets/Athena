using System;
using System.Collections.Generic;
using Athena.Data.Books;

namespace Athena.Data.Series {
    public class Series 
    {
        public Guid Id { get; set; }
        public string SeriesName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public override string ToString() {
            return SeriesName;
        } 
    }
}