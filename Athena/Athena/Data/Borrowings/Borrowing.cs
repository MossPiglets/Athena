using System;
using System.Collections.Generic;
using Athena.Data.Books;

namespace Athena.Data.Borrowings {
    public class Borrowing {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book Book { get; set; }

    }
}