using Athena.Data;
using Athena.Windows;
using System.Collections.Generic;

namespace Athena {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
			this.DataContext = this;
			BookList.ItemsSource =  new List<Book>();;
		}

        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			AddBookWindow AddBook = new AddBookWindow(); //dlaczego muszê to zrobiæ? czemu po prostu AddBookWindow.Show() nie dzia³a?
			AddBook.Show();
        }

        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			EditBookWindow EditBook = new EditBookWindow(); 
			EditBook.Show();
		}

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}