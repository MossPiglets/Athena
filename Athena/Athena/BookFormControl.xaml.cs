using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Athena.Data;
using Athena.Data.Books;
using Athena.Data.Series;
using Athena.EnumLocalizations;
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
        public ObservableCollection<Series> SeriesList { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public BookFormControl(string title, string buttonContent, Book book) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
            BookView = Mapper.Instance.Map<BookView>(book);
            this.Loaded += OnLoaded;
            AuthorCombobox.PreviewMouseRightButtonDown += AuthorOrPublisherComboboxOnPreviewMouseRightButtonDown;
            PublisherComboBox.PreviewMouseRightButtonDown += AuthorOrPublisherComboboxOnPreviewMouseRightButtonDown;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Authors.Load();
            Authors = new ObservableCollection<Author>(ApplicationDbContext.Authors.Local
                .ToList()
                .OrderBy(a => a.LastName));

            ApplicationDbContext.StoragePlaces.Load();
            StoragePlaces = new ObservableCollection<StoragePlace>(ApplicationDbContext.StoragePlaces.Local
                .ToList()
                .OrderBy(a => a.StoragePlaceName));

            ApplicationDbContext.PublishingHouses.Load();
            PublishingHouses = new ObservableCollection<PublishingHouse>(ApplicationDbContext.PublishingHouses.Local
                .ToList()
                .OrderBy(a => a.PublisherName));

            ApplicationDbContext.Series.Load();
            SeriesList = new ObservableCollection<Series>(ApplicationDbContext.Series.Local
                .ToList()
                .OrderBy(a => a.SeriesName));

            ApplicationDbContext.Categories.Load();
            Categories = new ObservableCollection<Category>(ApplicationDbContext.Categories.Local);

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

            CategoriesCombobox.ItemsSource = EnumSorter.GetSortedByDescriptions<CategoryName>();
            LanguageComboBox.ItemsSource = EnumSorter.GetSortedByDescriptions<Language>();
            SeriesComboBox.ItemsSource = SeriesList.Select(a => a).ToList();

            if (BookView.Series != null) {
                SeriesComboBox.SelectedItem = BookView.Series.SeriesName;
            }

            LanguageComboBox.SelectedItem = BookView.Language;
        }

        private void AddingAuthorCombobox(object sender, RoutedEventArgs e) {
            var authorAddingUserControl = new AuthorAdding();
            AuthorsStackPanel.Children.Add(authorAddingUserControl);
            authorAddingUserControl.AuthorComboBox.SelectionChanged += AuthorCombobox_OnSelectionChanged;
            authorAddingUserControl.DeleteButton.Click += AuthorComboBoxDeleteButton_OnClick;
        }

        private void AuthorComboBoxDeleteButton_OnClick(object sender, RoutedEventArgs e) {
            var button = (Button) sender;
            BookView.Authors.Remove((Author) button.DataContext);
        }

        private void AddSeries_Click(object sender, RoutedEventArgs e) {
            new AddSeriesWindow().Show();
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e) {
            new AddAuthorWindow().Show();
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
            categoryAddingUserControl.CategoryComboBox.SelectionChanged += CategoriesCombobox_OnSelectionChanged;
            categoryAddingUserControl.DeleteButton.Click += (o, args) => {
                BookView.Categories.Remove(BookView.Categories.First(a
                    => a.Name == (CategoryName) categoryAddingUserControl.CategoryComboBox.SelectedItem));
            };
        }

        private void AuthorCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.RemovedItems.Count > 0) {
                BookView.Authors.Remove((Author) e.RemovedItems[0]);
            }

            if (e.AddedItems.Count > 0) {
                if (!BookView.Authors.Any(a => Equals(a, e.AddedItems[0]))) {
                    BookView.Authors.Add((Author) e.AddedItems[0]);
                }
            }
        }

        private void CategoriesCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.RemovedItems.Count > 0) {
                BookView.Categories.Remove(BookView.Categories.First(a => a.Name == (CategoryName) e.RemovedItems[0]));
            }

            if (e.AddedItems.Count > 0) {
                if (!BookView.Categories.Any(a => a.Name == (CategoryName) e.AddedItems[0])) {
                    BookView.Categories.Add(Categories.First(a => a.Name == (CategoryName) e.AddedItems[0]));
                }
            }
        }

        private void PublishingHouseCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            BookView.PublishingHouse = (PublishingHouse) e.AddedItems[0];
        }

        private void StoragePlace_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            BookView.StoragePlace = (StoragePlace) e.AddedItems[0];
        }

        private void Series_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            BookView.Series = (Series) e.AddedItems[0];
        }

        private void LanguageComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            BookView.Language = (Language) e.AddedItems[0];
        }

        private void ButtonReturn_OnClick(object sender, RoutedEventArgs e) {
            Window.GetWindow(this)?.Close();
        }
        
        private void AuthorOrPublisherComboboxOnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            var comboBoxItem = (ComboBoxItem) VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (comboBoxItem == null) return;
            comboBoxItem.IsSelected = true;
            e.Handled = true;
        }

        private object VisualUpwardSearch(DependencyObject source) {
            while (source != null && !(source is ComboBoxItem))
                source = VisualTreeHelper.GetParent(source);

            return source as ComboBoxItem;
        }

        private void MenuItemDeleteAuthor_OnClick(object sender, RoutedEventArgs e) {
            var author = (Author) AuthorCombobox.SelectedItem;
            ApplicationDbContext.Authors.Remove(author);
            ApplicationDbContext.SaveChanges();
            Authors.Remove(author);
        }
        private void MenuItemDeletePublisher_OnClick(object sender, RoutedEventArgs e) {
            var publisher = (PublishingHouse)PublisherComboBox.SelectedItem;
            if (publisher.Books != null) { 
                ApplicationDbContext.PublishingHouses.Remove(publisher);
                ApplicationDbContext.SaveChanges();
                PublishingHouses.Remove(publisher); 
            }
            else {
                MessageBox.Show("Ten wydawca jest przypisany do jakiejś książki, nie można go usunąć.");
            }
        }
    }
}