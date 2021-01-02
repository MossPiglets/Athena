using System.Collections.Generic;

namespace Athena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            List<Data.Book> Books = new List<Data.Book>();

            var book1 = new Data.Book();
            book1.Title = "tytuł";

            Books.Add(book1);
           
            bookList.ItemsSource = Books;
        }

        private void Click_Edytuj_Książkę(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Click_Dodaj_Książkę(object sender, System.Windows.RoutedEventArgs e)
        {

        }

    }
}

