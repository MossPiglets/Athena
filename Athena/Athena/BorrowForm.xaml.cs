using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Athena {
    /// <summary>
    /// Interaction logic for BorrowForm.xaml
    /// </summary>
    public partial class BorrowForm {
        public BorrowForm() {
            InitializeComponent();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Validation.GetHasError(FirstName);
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e) { }
    }
}