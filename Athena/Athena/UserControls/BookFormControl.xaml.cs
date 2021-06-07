using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Athena.Data;
using Athena.Data.Books;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;
using Athena.EnumLocalizations;
using Athena.Windows;
using Castle.Core.Internal;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;


namespace Athena {
	public partial class BookFormControl : UserControl {
		public BookView BookView { get; set; }
		public string Title { get; set; }
		public string ButtonContent { get; set; }
		public ICommand ButtonCommand { get; set; }
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
			AuthorCombobox.PreviewMouseRightButtonDown += ComboboxOnPreviewMouseRightButtonDown;
			SeriesCombobox.PreviewMouseRightButtonDown += ComboboxOnPreviewMouseRightButtonDown;
			PublisherComboBox.PreviewMouseRightButtonDown += ComboboxOnPreviewMouseRightButtonDown;
			StoragePlaceComboBox.PreviewMouseRightButtonDown += ComboboxOnPreviewMouseRightButtonDown;
		}

		private void OnLoaded(object sender, RoutedEventArgs e) {
			Authors = ApplicationDbContext.Instance.Authors.LoadAsObservableCollection();
			StoragePlaces = ApplicationDbContext.Instance.StoragePlaces.LoadAsObservableCollection();
			PublishingHouses = ApplicationDbContext.Instance.PublishingHouses.LoadAsObservableCollection();
			SeriesList = ApplicationDbContext.Instance.Series.LoadAsObservableCollection();
			Categories = ApplicationDbContext.Instance.Categories.LoadAsObservableCollection();

			if (!BookView.Authors.IsNullOrEmpty()) {
				ConfigureAuthorsComboBoxes();
			}

			if (!BookView.Categories.IsNullOrEmpty()) {
				ConfigureCategoriesComboBox();
			}

			CategoriesCombobox.ItemsSource = EnumSorter.GetSortedByDescriptions<CategoryName>();
			LanguageComboBox.ItemsSource = EnumSorter.GetSortedByDescriptions<Language>();
		}

		private void ConfigureAuthorsComboBoxes() {
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

		private void ConfigureCategoriesComboBox() {
			CategoriesCombobox.SelectedItem = BookView.Categories.First().Name;
			for (int i = 1; i < BookView.Categories.Count; i++) {
				AddingCategoryCombobox_Click(this, new RoutedEventArgs());
				var categoryAdding = (CategoryAdding) CategoriesStackPanel.Children[i - 1];
				var combobox = categoryAdding.CategoryComboBox;
				combobox.SelectedItem = BookView.Categories.ToList()[i].Name;
			}
		}


		private void AddSeries_Click(object sender, RoutedEventArgs e) {
			new AddSeriesWindow().Show();
		}

		private void AddAuthor_Click(object sender, RoutedEventArgs e) {
            var addAuthorWindow = new AddAuthorWindow();
			addAuthorWindow.AuthorAdded += (_, e) => Authors.Add(e.Entity);
			addAuthorWindow.Show();
		}

		private void AddPublisher_Click(object sender, RoutedEventArgs e) {
			var addPublisherWindow = new AddPublisherWindow();
			addPublisherWindow.PublisherAdded += (_, e) => PublishingHouses.Add(e.Entity);
			addPublisherWindow.Show();
		}

		private void AddStoragePlace_Click(object sender, RoutedEventArgs e) {
			new AddStoragePlaceWindow().Show();
		}

		private void AddingAuthorCombobox(object sender, RoutedEventArgs e) {
			var authorAddingUserControl = new AuthorAdding();
			AuthorsStackPanel.Children.Add(authorAddingUserControl);
			authorAddingUserControl.AuthorComboBox.SelectionChanged += AuthorCombobox_OnSelectionChanged;
			authorAddingUserControl.DeleteButton.Click += AuthorComboBoxDeleteButton_OnClick;
		}

		private void AddingCategoryCombobox_Click(object sender, RoutedEventArgs e) {
			var categoryAddingUserControl = new CategoryAdding();
			CategoriesStackPanel.Children.Add(categoryAddingUserControl);
			categoryAddingUserControl.CategoryComboBox.SelectionChanged += CategoriesCombobox_OnSelectionChanged;
			categoryAddingUserControl.CategoryComboBox.SelectedIndex = 0;
			categoryAddingUserControl.DeleteButton.Click += (o, args) => {
				BookView.Categories.Remove(BookView.Categories.First(a
					=> a.Name == (CategoryName) categoryAddingUserControl.CategoryComboBox.SelectedItem));
			};
		}

		private void AuthorComboBoxDeleteButton_OnClick(object sender, RoutedEventArgs e) {
			var button = (Button) sender;
			BookView.Authors.Remove((Author) button.DataContext);
		}

		private void AllowOnlyNumbers(object sender, TextCompositionEventArgs e) {
			e.Handled = e.Text.Any(a => !char.IsDigit(a));
		}

		private void AllowPastOnlyNumbers(object sender, DataObjectPastingEventArgs e) {
			PastedTextValidator.AllowPastOnlyNumbers(e);
		}

		private T GetSelectedItem<T>(IList list) {
			if (list.Count != 0) {
				return (T) list[0];
			}

			return default(T);
		}

		private void PublishingHouseCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
			=> BookView.PublishingHouse = GetSelectedItem<PublishingHouse>(e.AddedItems);

		private void StoragePlace_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
			=> BookView.StoragePlace = GetSelectedItem<StoragePlace>(e.AddedItems);

		private void Series_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
			=> BookView.Series = GetSelectedItem<Series>(e.AddedItems);

		private void LanguageComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
			=> BookView.Language = GetSelectedItem<Language>(e.AddedItems);

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

		private void ButtonReturn_OnClick(object sender, RoutedEventArgs e) {
			Window.GetWindow(this)?.Close();
		}

		private void ConfirmButton_Click(object sender, RoutedEventArgs e) {
			var myWindow = Window.GetWindow(this);
			myWindow.Close();
		}

		private void ComboboxOnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) {
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
			ApplicationDbContext.Instance.Authors.Remove(author);
			ApplicationDbContext.Instance.SaveChanges();
			Authors.Remove(author);
		}

		private void MenuItemDeleteSeries_Click(object sender, RoutedEventArgs e) {
			var series = (Series) SeriesCombobox.SelectedItem;
			try {
				ApplicationDbContext.Instance.Series.Remove(series);
				ApplicationDbContext.Instance.SaveChanges();
				SeriesList.Remove(series);
			}
			catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
				MessageBox.Show("Istnieją książki należące do tej serii, nie można jej usunąć.", "Info",
					MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void MenuItemDeletePublisher_OnClick(object sender, RoutedEventArgs e) {
			var publisher = (PublishingHouse) PublisherComboBox.SelectedItem;
			try {
				ApplicationDbContext.Instance.PublishingHouses.Remove(publisher);
				ApplicationDbContext.Instance.SaveChanges();
				PublishingHouses.Remove(publisher);
			}
			catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
				MessageBox.Show("Ten wydawca jest przypisany do jakiejś książki, nie można go usunąć.", "Info",
					MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void MenuItemDeleteStoragePlace_OnClick(object sender, RoutedEventArgs e) {
			var storagePlace = (StoragePlace) StoragePlaceComboBox.SelectedItem;
			try {
				ApplicationDbContext.Instance.StoragePlaces.Remove(storagePlace);
				ApplicationDbContext.Instance.SaveChanges();
				StoragePlaces.Remove(storagePlace);
			}
			catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
				MessageBox.Show("To miejsce przechowywania jest przypisane do jakiejś książki, nie można go usunąć.",
					"Info", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void AuthorCombobox_LostFocus(object sender, RoutedEventArgs e) {
			if (AuthorCombobox.Text.IsNullOrEmpty()) {
				return;
			}

			if (AuthorCombobox.Items.Cast<Author>().All(a => a.ToString() != AuthorCombobox.Text)) {
				AuthorCombobox.Text = string.Empty;
				MessageBox.Show("Wprowadzony autor nie istnieje. Użyj opcji dodaj autora.", "Info", MessageBoxButton.OK,
					MessageBoxImage.Information);
			}
		}

		private void PublisherComboBox_LostFocus(object sender, RoutedEventArgs e) {
			if (PublisherComboBox.Text.IsNullOrEmpty()) {
				return;
			}

			if (PublisherComboBox.Items.Cast<PublishingHouse>().All(a => a.ToString() != PublisherComboBox.Text)) {
				PublisherComboBox.Text = string.Empty;
				MessageBox.Show("Wprowadzone wydawnictwo nie istnieje. Użyj opcji dodaj wydawnictwo.", "Info",
					MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void SeriesCombobox_LostFocus(object sender, RoutedEventArgs e) {
			if (SeriesCombobox.Text.IsNullOrEmpty()) {
				return;
			}

			if (SeriesCombobox.Items.Cast<Series>().All(a => a.ToString() != SeriesCombobox.Text)) {
				SeriesCombobox.Text = string.Empty;
				MessageBox.Show("Wprowadzona seria nie istnieje. Użyj opcji dodaj serię.", "Info", MessageBoxButton.OK,
					MessageBoxImage.Information);
			}
		}

		private void StoragePlaceComboBox_LostFocus(object sender, RoutedEventArgs e) {
			if (StoragePlaceComboBox.Text.IsNullOrEmpty()) {
				return;
			}

			if (StoragePlaceComboBox.Items.Cast<StoragePlace>().All(a => a.ToString() != StoragePlaceComboBox.Text)) {
				StoragePlaceComboBox.Text = string.Empty;
				MessageBox.Show(
					"Wprowadzone miejsce przechowywania nie istnieje. Użyj opcji dodaj miejsce przechowywania.", "Info",
					MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}
	}
}