using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Athena.Data.Books;
using Athena.Windows;
using Microsoft.EntityFrameworkCore;

namespace Athena
{

    public partial class BookFormControl : UserControl {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public BookFormControl(string title, string buttonContent, Book book) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
            //Book = book;
            // tu będę mapować book na BookView za pomocą automapera
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Authors.Load();
            Authors = ApplicationDbContext.Authors.Local.ToObservableCollection();
        }

        public BookView Book { get; set; } = new BookView();

        public string Title { get; set; }

        public string ButtonContent { get; set; }

        public ICommand ButtonCommand { get; set; }

        private void AddingAuthorCombobox(object sender, RoutedEventArgs e)
        {
            var myUserControl = new AuthorAdding();
            AuthorsStackPanel.Children.Add(myUserControl);
        }

        private void AddSeries_Click(object sender, RoutedEventArgs e) {
            new AddSeriesWindow().Show();
        }

        private void AddPublisher_Click(object sender, RoutedEventArgs e) {
            new AddPublisherWindow().Show();
        }
        // zrób maping z Book na BookView 
        // Uzyj automapera
        // Wyszukaj czy jest wsparcie dla wpf automapera, jak nie to domyślny

    }
}