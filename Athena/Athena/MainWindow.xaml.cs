using System.Collections.Generic;

namespace Athena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Data.Book> books = new List<Data.Book>();
            Data.Book book = new Data.Book();
            book.Title = "Tytuł";
            book.ISBN = "ISBN";
            book.StoragePlace = new Data.StoragePlace();
            book.StoragePlace.StoragePlaceName = "Miejsce przechowywania";
            book.Publisher = new Data.PublishingHouse();
            book.Publisher.Publisher = "Wydawca";
            book.PublishmentYear = new System.DateTime(2001);
            book.Series = new Data.Series();
            book.Series.VolumeNumber = 1;
            Data.Book book1 = new Data.Book();
            book1.Title = "Tytuł2";
            book1.ISBN = "ISBN2";
            book1.StoragePlace = new Data.StoragePlace();
            book1.StoragePlace.StoragePlaceName = "Miejsce przechowywania2";
            book1.Publisher = new Data.PublishingHouse();
            book1.Publisher.Publisher = "Wydawca2";
            book1.PublishmentYear = new System.DateTime(2002);
            book1.Series = new Data.Series();
            book1.Series.SeriesName = "Seria2";
            book1.Series.VolumeNumber = 2;
            books.Add(book);
            books.Add(book1);
            bookList.ItemsSource = books;
        }
    }
}
