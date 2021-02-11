using Athena.Data;
using Athena.Windows;
using System.Collections.Generic;
using System.Windows;
using Athena.Import;
using Castle.Core.Internal;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Athena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public MainWindow() {

            InitializeComponent();
            this.DataContext = this;
            ApplicationDbContext = new ApplicationDbContext();

            #region
            //To be delated
            Book book = new Book();
            book.Title = "Tytu³";
            book.ISBN = "23";
            var publisher = new PublishingHouse();
            publisher.PublisherName = "Wydawca";
            Author author = new Author() { FirstName = "Test", LastName = "Testowy" };
            Author author2 = new Author() { FirstName = "Test2", LastName = "Testowy2" };
            Author author3 = new Author() { FirstName = "Test3", LastName = "Testowy3"};
            StoragePlace storagePlace = new StoragePlace() { StoragePlaceName = "Miejsce przehcowywania" };
            Series seria = new Series() { SeriesName = "Seria" };
            book.Series = seria;
            var wyp = new Borrowing();
            book.Borrowing = wyp;
            book.StoragePlace = storagePlace;
            book.Authors = new List<Author>();
            book.PublishingHouse = publisher;
            book.Authors.Add(author2);
            book.Authors.Add(author);
            book.Authors.Add(author3);
            ApplicationDbContext.Books.Add(book);
            #endregion

            ApplicationDbContext.Books.Load();
            Books = ApplicationDbContext.Books.Local.ToObservableCollection();

            //BookList.ItemsSource = new List<Book>();
            if (!BookList.ItemsSource.IsNullOrEmpty()) {
                ImportButton.Visibility = Visibility.Hidden;
            }
        }

        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			AddBookWindow addBook = new AddBookWindow();
			addBook.Show();
        }

        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Book book = (Book)BookList.SelectedItem;
			EditBookWindow editBook = new EditBookWindow(book); 
			editBook.Show();
		}

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e) { }

        private void ImportData(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;
            if (fileName == "") {
                throw new ImportException("File is not choose. Please, choose a file to import.");
            }
            var dataImporter = new DataBaseImporter();
            dataImporter.ImportFromSpreadsheet(fileName);

            ImportButton.Visibility = Visibility.Hidden;
        }
    }
}