using Athena.Windows;
using System.ComponentModel;
using System.Windows;
using Athena.Import;
using Castle.Core.Internal;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Athena.Data.Books;
using System.Linq;
using System;
using System.Collections.Specialized;
using System.Windows.Input;

namespace Athena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public ObservableCollection<BookInListView> Books { get; set; }

        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
            ApplicationDbContext.Instance.Books
                .Include(b => b.Series)
                .Include(b => b.PublishingHouse)
                .Include(b => b.StoragePlace)
                .Include(b => b.Authors)
                .Include(b => b.Categories)
                .Include(b => b.Borrowing.OrderByDescending(b => b.BorrowDate))
                .Load();
            Books = Mapper.Instance.Map<ObservableCollection<BookInListView>>(ApplicationDbContext.Instance.Books.Local.ToObservableCollection());

            if (!Books.IsNullOrEmpty()) {
                ImportButton.Visibility = Visibility.Collapsed;
            }

            ApplicationDbContext.Instance.ChangeTracker.StateChanged += (sender, e) => {
                if (e.Entry.Entity is Book book && e.NewState == EntityState.Modified)
                {
                    var bookInList = Books.Single(b => b.Id == book.Id);
                    Mapper.Instance.Map(book, bookInList);
                }
            };
            ApplicationDbContext.Instance.Books.Local.CollectionChanged += (sender, e) => {
                if(e.NewItems != null) {
                    foreach (Book item in e?.NewItems)
                    {
                        if (Books.All(b => b.Id != item.Id)) {
                            Application.Current.Dispatcher.Invoke(() => Books.Add(Mapper.Instance.Map<BookInListView>(item)));
                        }
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove){
                    var book = (Book)e.OldItems[0];
                    var bookInList = Books.First(b => b.Id == book.Id);
                    Books.Remove(bookInList); 
                } 
            };
            this.Closed += (sender, args) => Application.Current.Shutdown();
            ApplicationDbContext.Instance.Borrowings.Local.CollectionChanged += (sender, e) => {  };
        }
        private static RoutedUICommand _menuItemBorrow_Click;
        public static RoutedUICommand MenuItemBorrow_Click
        {
            get
            {
                if (_menuItemBorrow_Click == null)
                {
                    _menuItemBorrow_Click = new RoutedUICommand("MenuItemBorrow_Click", "MenuItemBorrow_Click", typeof(MainWindow));
                }
                return _menuItemBorrow_Click;
            }
        }
        private void cb_MenuItemBorrow_Click_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Book book = ApplicationDbContext.Instance.Books.Single(b => b.Id == ((BookInListView)BookList.SelectedItem).Id);
            BorrowForm borrowForm = new BorrowForm(book);
            borrowForm.Show();
        }
        private void cb_MenuItemBorrow_Click_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (((BookInListView)BookList.SelectedValue).Borrowing.Count > 0 && ((BookInListView)BookList.SelectedValue).Borrowing[0].ReturnDate == null && !((BookInListView)BookList.SelectedValue).Borrowing[0].FirstName.IsNullOrEmpty())
            if(!((BookInListView)BookList.SelectedValue).LastBorrowName.IsNullOrEmpty())
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }
        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e) {
            Book book = ApplicationDbContext.Instance.Books.Single(b => b.Id == ((BookInListView)BookList.SelectedItem).Id);
            EditBookWindow editBook = new EditBookWindow(book);
            editBook.Show();
        }

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e) {
            var book = ApplicationDbContext.Instance.Books.Single(b => b.Id == ((BookInListView)BookList.SelectedItem).Id);
            ApplicationDbContext.Instance.Books.Remove(book);
            ApplicationDbContext.Instance.SaveChanges();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenBorrowedBookList_Click(object sender, RoutedEventArgs e)
        {
            BorrowedBooksListWindow borrowedBooks = new BorrowedBooksListWindow();
            borrowedBooks.Show();
        }
        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddBookWindow addBook = new AddBookWindow();
            addBook.Show();
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

        private void BookList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Book book = Mapper.Instance.Map<Book>(BookList.SelectedItem);
            EditBookWindow editBook = new EditBookWindow(book);
            editBook.Show();
        }
    }
}