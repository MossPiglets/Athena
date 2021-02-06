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
			BookList.ItemsSource = new List<Book>() { new Book() {Title = "coœ", ISBN = "10" }, new Book() { Title = "coœ2", ISBN = "12" } };
		}

        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			AddBookWindow AddBook = new AddBookWindow();
			AddBook.Show();
        }

        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Book book = (Book)BookList.SelectedItem;
			EditBookWindow EditBook = new EditBookWindow(book); 
			EditBook.Show();
		}

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        
        }
    }
}