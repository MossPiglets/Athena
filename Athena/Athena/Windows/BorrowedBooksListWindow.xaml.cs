using System.Collections.ObjectModel;
using Athena.Data.Borrowings;
using Microsoft.EntityFrameworkCore;

namespace Athena.Windows
{
    public partial class BorrowedBooksListWindow
    {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Borrowing> Borrowings { get; set; }
        public BorrowedBooksListWindow() {
            InitializeComponent();
            this.DataContext = this;
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Borrowings
                .Include(a => a.Book)
                .Include(a => a.Book.StoragePlace)
                .Include(a => a.Book.PublishingHouse)
                .Include(a => a.Book.Authors)
                .Load();
            Borrowings = ApplicationDbContext.Borrowings.Local.ToObservableCollection();
            BorrowedBookList.ItemsSource = Borrowings;
        }
    }
}
