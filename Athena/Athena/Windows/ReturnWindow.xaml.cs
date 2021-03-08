using Athena.Data.Books;
using Castle.Core.Internal;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Athena.Windows
{
    public partial class ReturnWindow
    {
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
            Calendar.SelectedDate = DateTime.Today;
            Calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Today.AddDays(1), DateTime.Today.AddDays(1).AddYears(1000)));
            Calendar.BlackoutDates.Add(new CalendarDateRange(/*odwołać się do daty wybranej przy pożyczaniu,*/ DateTime.Today.AddDays(1)));

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
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
