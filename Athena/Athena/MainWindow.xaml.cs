using Athena.Data;
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

        private void ImportData(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;
            using var importData = new SpreadsheetDataImport(fileName);
            var a = importData.ImportPublishingHousesList();
            var b = importData.ImportCategoriesList();
            var c = importData.ImportSeriesList();
            var d = importData.ImportAuthorsList();
            var f = importData.ImportStoragePlacesList();
            ImportButton.Visibility = Visibility.Hidden;
        }
    }
}