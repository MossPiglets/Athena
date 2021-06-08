using System;
using System.Collections.ObjectModel;
using System.Linq;
using Athena.Data.Borrowings;
using Microsoft.EntityFrameworkCore;
using Athena.Data.Books;
using System.Windows.Controls;
using System.Windows;


namespace Athena.Windows {
    public partial class BorrowedBooksListWindow {
        public ObservableCollection<Borrowing> Borrowings { get; set; }
        public BorrowedBooksListWindow() {
            InitializeComponent();
            this.DataContext = this;
            ApplicationDbContext.Instance.Borrowings
                .Include(a => a.Book)
                .ThenInclude(a => a.StoragePlace)
                .Include(a => a.Book)
                .ThenInclude(a => a.PublishingHouse)
                .Include(a => a.Book)
                .ThenInclude(a => a.Authors)
                .Load();
            Borrowings = ApplicationDbContext.Instance.Borrowings.Local.ToObservableCollection();
            BorrowedBookList.ItemsSource = Borrowings;
        }

        private void OpenReturnWindow_Click(object sender, System.Windows.RoutedEventArgs e) {
            Button button = (Button) sender;
            Borrowing borrowing = (Borrowing) button.DataContext;
            Book book = borrowing.Book;
            book.Borrowing.Add(borrowing);
            ReturnWindow returnWindow = new ReturnWindow(book);
            returnWindow.BookReturned += (_, args) => button.Visibility = Visibility.Hidden;
            returnWindow.Show();
        }
    }
}