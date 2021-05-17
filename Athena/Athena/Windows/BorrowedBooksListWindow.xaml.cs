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
        public ObservableCollection<Book> Books { get; set; }

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
            ApplicationDbContext.Instance.Books
                .Include(b => b.Series)
                .Include(b => b.PublishingHouse)
                .Include(b => b.StoragePlace)
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .Include(b => b.Borrowing.OrderByDescending(b => b.BorrowDate))
                .Load();
            Books = ApplicationDbContext.Instance.Books.Local.ToObservableCollection();
            BorrowedBookList.ItemsSource = Borrowings;
            if (Borrowings.Count == 0) {
                TextBlock.Visibility = Visibility.Visible;
            }
        }

        private void OpenReturnWindow_Click(object sender, System.Windows.RoutedEventArgs e) {
            Button button = (Button) sender;
            Borrowing borrowedBook = (Borrowing) button.DataContext;
            Book book = borrowedBook.Book;
            book.Borrowing.Add(borrowedBook);
            ReturnWindow returnWindow = new ReturnWindow(book);
            returnWindow.BookReturned += (_, args) => button.Visibility = Visibility.Hidden;
            returnWindow.Show();
        }
    }
}