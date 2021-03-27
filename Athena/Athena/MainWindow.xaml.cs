using Athena.Data;
using Athena.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Athena.Import;
using Castle.Core.Internal;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Athena.Data.Books;
using System.Linq;
using Athena.Data.Series;
using System;

namespace Athena {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<BookInListView> Books { get; set; }

        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Books
                .Include(b => b.Series)
                .Include(b => b.PublishingHouse)
                .Include(b => b.StoragePlace)
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .Include(b => b.Borrowing.OrderByDescending(b => b.BorrowDate))
                .Load();
            Books = Mapper.Instance.Map<ObservableCollection<BookInListView>>(ApplicationDbContext.Books.Local.ToObservableCollection());

            if (!Books.IsNullOrEmpty()) {
                ImportButton.Visibility = Visibility.Collapsed;
            }

            this.Closed += (sender, args) => Application.Current.Shutdown();
        }

        private void MenuItemBorrow_Click(object sender, RoutedEventArgs e) {
            Book book = Mapper.Instance.Map<Book>(BookList.SelectedItem);
            BorrowForm borrowForm = new BorrowForm(book);
            borrowForm.Show();
        }

        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e) {
            AddBookWindow addBook = new AddBookWindow();
            addBook.Show();
        }

        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e) {
            Book book = Mapper.Instance.Map<Book>(BookList.SelectedItem);
            EditBookWindow editBook = new EditBookWindow(book);
            editBook.Show();
        }

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e) {
            Book book = Mapper.Instance.Map<Book>(BookList.SelectedItem);
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
            var fileName = (string) e.Argument;
            var dataImporter = new DatabaseImporter();
            dataImporter.ImportFromSpreadsheet(fileName);
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

            var text = SearchTextBox.Text;
            if (text.Length == 0)
                BookList.ItemsSource = Books;
            if (text.Length < 3)
                return;
            var fillteredBooks = Books.Where(b => b.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase) ||
                                            (b.Series?.SeriesName != null && b.Series.SeriesName.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
                                            (b.PublishingHouse?.PublisherName != null && b.PublishingHouse.PublisherName.Contains(text, StringComparison.CurrentCultureIgnoreCase)) ||
                                            (b.Authors.Any(a => a.ToString().Contains(text, StringComparison.CurrentCultureIgnoreCase)))
                                            );
                                            
            BookList.ItemsSource = fillteredBooks;
        }
    }
}