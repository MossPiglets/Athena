using Athena.Data;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Athena.Import;
using Microsoft.Win32;

namespace Athena {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow {
		public MainWindow() {
			InitializeComponent();
			this.DataContext = this;
			BookList.ItemsSource =  new List<Book>();
		}

        private void ImportData(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;
            using var importData = new SpreadsheetDataImport(fileName);
            var a = importData.ImportAuthorsList();
        }
		//todo
		//ten przycisk ma sie pojawiac tylko jesli nie ma w MainWindow rzadnych zainportowanych danych
    }
}