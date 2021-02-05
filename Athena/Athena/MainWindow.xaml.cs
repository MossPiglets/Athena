using Athena.Data;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Athena.Import;
using Athena.Windows;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public MainWindow() {

            InitializeComponent();
            this.DataContext = this;
            Book book = new Book();
            book.Title = "Tytu³";
            Author author = new Author() { FirstName = "Test", LastName = "Testowy" };
            Author author2 = new Author() { FirstName = "Test2", LastName = "Testowy2" };
            Author author3 = new Author() { FirstName = "Test3", LastName = "Testowy3", Id = new System.Guid()};
            ApplicationDbContext = new ApplicationDbContext();
            
            StoragePlace storagePlace = new StoragePlace() { StoragePlaceName = "Miejsce przehcowywania" };
            book.StoragePlace = storagePlace;
            book.Authors = new List<Author>();
            
            book.Authors.Add(author2);
            book.Authors.Add(author);
            book.Authors.Add(author3);
            ApplicationDbContext.Books.Add(book);
            ApplicationDbContext.Books.Load();
            Books = ApplicationDbContext.Books.Local.ToObservableCollection();

            //BookList.ItemsSource = new List<Book>();
            if (!BookList.ItemsSource.IsNullOrEmpty()) {
                ImportButton.Visibility = Visibility.Hidden;
            }
        }

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