using System;
using Athena.Data;
using Athena.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Athena.Import;
using Athena.Windows;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Athena.Data.Books;

namespace Athena {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;

            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Books.Load();
            BookList.ItemsSource = ApplicationDbContext.Books.Local.ToObservableCollection();

            //BookList.ItemsSource = new List<Book>();
            if (!BookList.ItemsSource.IsNullOrEmpty()) {
                ImportButton.Visibility = Visibility.Hidden;
            }
        }
 
        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e) {
            AddBookWindow addBook = new AddBookWindow();
            addBook.Show();
        }

        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e) {
            Book book = (Book) BookList.SelectedItem;
            EditBookWindow editBook = new EditBookWindow(book);
            editBook.Show();
        }

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Book book = (Book)BookList.SelectedItem;
			ApplicationDbContext context = new ApplicationDbContext();
            context.Books.Remove(book);
			context.SaveChanges();
		}

        private void ImportData(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;
            if (fileName == "") {
                return;
            }

            BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
            ImportButton.Visibility = Visibility.Hidden;
            ImportText.Visibility = Visibility.Visible;
            ProgressBarStatus.Visibility = Visibility.Visible;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += (o, args) => {
                ImportText.Visibility = Visibility.Hidden;
                ProgressBarStatus.Visibility = Visibility.Hidden;
            };
            worker.RunWorkerAsync(argument: fileName);
        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ProgressBarStatus.Value = e.ProgressPercentage;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e) {
            // podepnê siê do eventu z klasy DatabaseImporter
            var fileName = (string) e.Argument;
            var dataImporter = new DatabaseImporter();
            dataImporter.ImportFromSpreadsheet(fileName);
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            IEnumerable<Book> books = (IEnumerable<Book>)BookList.ItemsSource;
            var searchresult = books.Where(b => b.Title.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                                (b.Series ?? new Series {SeriesName=""}).SeriesName.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                                (b.PublishingHouse ?? new PublishingHouse{ PublisherName= ""}).PublisherName.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                                (b.Authors ?? new List<Author> { new Author { FirstName = "", LastName = "" } }).First().ToString().ToLower().Contains(SearchTextBox.Text.ToLower())
                                                 );
            BookList.ItemsSource = searchresult;
        }
    }
}