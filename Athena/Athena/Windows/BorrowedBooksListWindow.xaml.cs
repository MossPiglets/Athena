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
                .ThenInclude(a => a.StoragePlace)
                .Include(a => a.Book)
                .ThenInclude(a => a.PublishingHouse)
                .Include(a => a.Book)
                .ThenInclude(a => a.Authors)
                .Load();
            Borrowings = ApplicationDbContext.Borrowings.Local.ToObservableCollection();
            BorrowedBookList.ItemsSource = Borrowings;
        }
    }
}
