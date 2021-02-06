using Athena.Data;
using Athena.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Athena.Import;
using Athena.Windows;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;


namespace Athena {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
			this.DataContext = this;
			BookList.ItemsSource = new List<Book>();
			if (!BookList.ItemsSource.IsNullOrEmpty()) {
				ImportButton.Visibility = Visibility.Hidden;
			}
		}

        private void AddBook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			AddBookWindow addBook = new AddBookWindow();
			addBook.Show();
        }

        private void MenuItemEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			Book book = (Book)BookList.SelectedItem;
			EditBookWindow editBook = new EditBookWindow(book); 
			editBook.Show();
		}

        private void MenuItemDelete_Click(object sender, System.Windows.RoutedEventArgs e) { }

        private void ImportData(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;
            using var importData = new SpreadsheetDataImport(fileName);
            var books = importData.ImportBooksList();
            ImportButton.Visibility = Visibility.Hidden;
        }
    }
}