using Athena.Data;
using System.Collections.Generic;
using System.Windows;
using Athena.Windows;

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

		private void AddBook_OnClick(object sender, RoutedEventArgs e) {
			new AddBookWindow().Show();
		}
	}
}