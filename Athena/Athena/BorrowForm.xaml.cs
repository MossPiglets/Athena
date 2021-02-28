using System;
using System.Linq;
using System.Windows;
using Athena.Data;
using Athena.Data.Books;
using Castle.Core.Internal;

namespace Athena {
    /// <summary>
    /// Interaction logic for BorrowForm.xaml
    /// </summary>
    public partial class BorrowForm {
        public Borrowing Borrowing { get; set; }

        public BorrowForm(Book book) {
            InitializeComponent();
            this.DataContext = this;
            Title.Text = book.Title;
            var authors = ToAuthorsNames(book);
            if (!authors.IsNullOrEmpty()) {
                Author.Text = authors;
            }
            Borrowing = new Borrowing();
            Calendar.SelectedDate = DateTime.Today;
        }

        public string ToAuthorsNames(Book book) {
            string authors = string.Empty;
            if (book.Authors.Count > 0) {
                for (int i = 0; i < book.Authors.Count; i++) {
                    var authorsList = book.Authors.ToList();
                    if (i == 0) {
                        authors = $"{authorsList[i].FirstName} {authorsList[i].LastName}";
                        continue;
                    }

                    authors = $"{authors} \n {authorsList[i].FirstName} {authorsList[i].LastName}";
                }
            }

            return authors;
        }

        private void Borrow_OnClick(object sender, RoutedEventArgs e) {
            using var context = new ApplicationDbContext();
            Borrowing.Id = Guid.NewGuid();
            Borrowing.BorrowDate = Calendar.SelectedDate.Value;
            context.Borrowings.Add(Borrowing);
            context.SaveChanges();
            this.Close();
        }
    }
}