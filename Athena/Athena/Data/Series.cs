using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Athena.Data {
    public class Series 
    {
        public Guid Id { get; set; }
        public string SeriesName { get; set; }
        public int VolumeNumber { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new ObservableCollection<Book>();
    }
}