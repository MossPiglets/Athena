using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Athena.Data;
using Athena.Windows;

namespace Athena {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            //var addBookWindow = new AddBookWindow();
            //addBookWindow.Show();
            var editBookWindow = new EditBookWindow();
            editBookWindow.Show();
        }
    }
}