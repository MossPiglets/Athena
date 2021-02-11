using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Athena.Data {
    public class Borrowing {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public override string ToString()
        {
            if(String.IsNullOrEmpty(FirstName) && String.IsNullOrEmpty(LastName))
            {
                return "Niewypożyczone";
            }
            else
            {
                return "Wypożyczone";
            }
        }
    }
}