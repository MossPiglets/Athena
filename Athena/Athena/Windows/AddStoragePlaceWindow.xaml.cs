using System.Windows.Controls;
using System.Windows.Input;

namespace Athena.Windows
{
    public partial class AddStoragePlaceWindow
    {
        public AddStoragePlaceWindow()
        {
            InitializeComponent();
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(StoragePlaceTextBox);
        }
    }
}
