using Athena.Data.Books;
using Athena.Data.Borrowings;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Athena.Windows
{
    public partial class ReturnWindow
    {
        public Borrowing Borrowing{ get; set; }
        public Button Button { get; set; }

      
        public ReturnWindow(Book book)
        {
            InitializeComponent();
            this.DataContext = this;
            Title.Text = book.Title;
            var authors = ToAuthorsNames(book);
            if (!authors.IsNullOrEmpty())
            {
                Author.Text = authors;
            }

            Borrowing = new Borrowing();
            Borrowing = book.Borrowing[book.Borrowing.Count() - 1];
            Calendar.SelectedDate = DateTime.Today;
            Calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Today.AddDays(1), DateTime.Today.AddDays(1).AddYears(1000)));
            Calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Today.AddDays(-1).AddYears(-1000), (book.Borrowing[book.Borrowing.Count() - 1].BorrowDate).AddDays(-1)));
        }


        public string ToAuthorsNames(Book book)
        {
            StringBuilder builder = new StringBuilder();
            if (book.Authors.Count > 0)
            {
                for (int i = 0; i < book.Authors.Count; i++)
                {
                    var authorsList = book.Authors.ToList();
                    if (i == 0)
                    {
                        builder.Append($"{authorsList[i].FirstName} {authorsList[i].LastName}");
                        continue;
                    }
                    builder.Append($"\n {authorsList[i].FirstName} {authorsList[i].LastName}");
                }
            }

            return builder.ToString();
        }

        private void ReturnBorrowedBook_Click(object sender, RoutedEventArgs e)
        {
            Borrowing.ReturnDate = Calendar.SelectedDate.Value;
            ApplicationDbContext.Instance.Entry(Borrowing).State = EntityState.Modified;
            ApplicationDbContext.Instance.SaveChanges();
            ReturnBook.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        public event EventHandler ReturnBook;

    }
}
