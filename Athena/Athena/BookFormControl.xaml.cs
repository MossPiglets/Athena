using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena
{

    public partial class BookFormControl : UserControl {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Author> Authors { get; set; }
        public BookFormControl(string title, string buttonContent) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
          
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Authors.Load();
            Authors = ApplicationDbContext.Authors.Local.ToObservableCollection();
        }

        public Book Book { get; set; } = new Book();

        public string Title { get; set; }

        public string ButtonContent { get; set; }

        public ICommand ButtonCommand { get; set; }

        private void AddingAuthorCombobox(object sender, RoutedEventArgs e)
        {

            var myUserControl = new AuthorAdding();
            AuthorsStackPanel.Children.Add(myUserControl);
        }

    }
}