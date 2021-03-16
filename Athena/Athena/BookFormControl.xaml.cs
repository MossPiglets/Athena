using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Athena.Data.Books;
using Athena.Windows;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;


namespace Athena {
    public partial class BookFormControl : UserControl {
        public BookView BookView { get; set; }
        public string Title { get; set; }
        public string ButtonContent { get; set; }
        public ICommand ButtonCommand { get; set; }
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public ObservableCollection<StoragePlace> StoragePlaces { get; set; }
        public ObservableCollection<PublishingHouse> PublishingHouses { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public BookFormControl(string title, string buttonContent, Book book) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
            BookView = Mapper.Instance.Map<BookView>(book);
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Authors.Load();
            Authors = ApplicationDbContext.Authors.Local.ToObservableCollection();
            ApplicationDbContext.StoragePlaces.Load();
            StoragePlaces = ApplicationDbContext.StoragePlaces.Local.ToObservableCollection();
            ApplicationDbContext.PublishingHouses.Load();
            PublishingHouses = ApplicationDbContext.PublishingHouses.Local.ToObservableCollection();
            ApplicationDbContext.Categories.Load();
            Categories = ApplicationDbContext.Categories.Local.ToObservableCollection();
            if (!BookView.Authors.IsNullOrEmpty()) {
                AuthorCombobox.SelectedIndex = Authors.IndexOf(BookView.Authors.ToList()[0]);
                if (BookView.Authors.Count > 1) {
                    for (int i = 1; i < BookView.Authors.Count; i++) {
                        AddingAuthorCombobox(this, new RoutedEventArgs());
                        var authorAdding = (AuthorAdding) AuthorsStackPanel.Children[i - 1];
                        var combobox = authorAdding.AuthorComboBox;
                        combobox.SelectedIndex = Authors.IndexOf(BookView.Authors.ToList()[i]);
                    }
                }
            }

            if (!BookView.Categories.IsNullOrEmpty()) {
                CategoriesCombobox.SelectedItem = BookView.Categories.First().Name;
                for (int i = 1; i < BookView.Categories.Count; i++) {
                    AddingCategoryCombobox_Click(this, new RoutedEventArgs());
                    var categoryAdding = (CategoryAdding) CategoriesStackPanel.Children[i - 1];
                    var combobox = categoryAdding.CategoryComboBox;
                    combobox.SelectedItem = BookView.Categories.ToList()[i].Name;
                }
            }
        }

        private void AddingAuthorCombobox(object sender, RoutedEventArgs e) {
            var authorAddingUserControl = new AuthorAdding();
            AuthorsStackPanel.Children.Add(authorAddingUserControl);
        }

        private void AddSeries_Click(object sender, RoutedEventArgs e) {
            new AddSeriesWindow().Show();
        }

        private void AddPublisher_Click(object sender, RoutedEventArgs e) {
            new AddPublisherWindow().Show();
        }

        private void AddStoragePlace_Click(object sender, RoutedEventArgs e) {
            new AddStoragePlaceWindow().Show();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e) {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e) {
            e.Handled = e.Text.Any(a => !char.IsDigit(a));
        }

        private void AllowPastOnlyNumbers(object sender, DataObjectPastingEventArgs e) {
            if (e.DataObject.GetDataPresent(typeof(string))) {
                string text = (string) e.DataObject.GetData(typeof(string));
                if (text.Any(a => !char.IsDigit(a))) {
                    e.CancelCommand();
                }
            }
            else {
                e.CancelCommand();
            }
        }

        private void AddingCategoryCombobox_Click(object sender, RoutedEventArgs e) {
            var categoryAddingUserControl = new CategoryAdding();
            CategoriesStackPanel.Children.Add(categoryAddingUserControl);
        }
    }
}