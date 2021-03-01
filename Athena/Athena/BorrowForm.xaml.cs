using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Athena.Data.Books;
using Athena.Data.Borrowing;
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
            StringBuilder builder = new StringBuilder();
            if (book.Authors.Count > 0) {
                for (int i = 0; i < book.Authors.Count; i++) {
                    var authorsList = book.Authors.ToList();
                    if (i == 0) {
                        builder.Append($"{authorsList[i].FirstName} {authorsList[i].LastName}");
                        continue;
                    }
                    builder.Append($"\n {authorsList[i].FirstName} {authorsList[i].LastName}");
                }
            }

            return builder.ToString();
        }

        private void Borrow_OnClick(object sender, RoutedEventArgs e) {
            using var context = new ApplicationDbContext();
            Borrowing.Id = Guid.NewGuid();
            Borrowing.BorrowDate = Calendar.SelectedDate.Value;
            context.Borrowings.Add(Borrowing);
            context.SaveChanges();
            this.Close();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Validation.GetHasError(FirstName);
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e) { }
    }
}