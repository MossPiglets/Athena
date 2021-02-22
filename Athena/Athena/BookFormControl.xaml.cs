using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Athena.Data.Books;
using Athena.Windows;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    public partial class BookFormControl : UserControl {
        public BookView BookView { get; set; }
        public string Title { get; set; }
        public string ButtonContent { get; set; }
        public ICommand ButtonCommand { get; set; }
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Author> Authors { get; set; }


        public BookFormControl(string title, string buttonContent, Book book) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
            BookView = Mapper.Instance.Map<BookView>(book);
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Authors.Load();
            Authors = ApplicationDbContext.Authors.Local.ToObservableCollection();
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
    }
}