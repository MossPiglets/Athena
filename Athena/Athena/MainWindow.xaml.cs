using Athena.Data;
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

    }
}