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
        public ObservableCollection<BorrowingView> Borrowings { get; set; }
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
            Borrowings = Mapper.Instance.Map<ObservableCollection<BorrowingView>>(ApplicationDbContext.Instance.Borrowings.Local.ToObservableCollection());
            BorrowedBookList.ItemsSource = Borrowings;
            if (Borrowings.Count == 0) {
                TextBlock.Visibility = Visibility.Visible;
            }
        }

        private void OpenReturnWindow_Click(object sender, System.Windows.RoutedEventArgs e) {
            Button button = (Button) sender;
            var borrowing = (BorrowingView) button.DataContext;
            Book book = borrowing.Book;
            book.Borrowing.Add(Mapper.Instance.Map<Borrowing>(borrowing));
            ReturnWindow returnWindow = new ReturnWindow(book);
            returnWindow.BookReturned += (_, args) => button.Visibility = Visibility.Hidden;
            returnWindow.BookReturned += (sender, e) => Borrowings.Single(b => b.Id == borrowing.Id).ReturnDate = e.Value.ReturnDate; 
            returnWindow.BookReturned += (sender, e) => BorrowedBookList.ItemsSource = Borrowings;
            returnWindow.Show();
        }
    }
}