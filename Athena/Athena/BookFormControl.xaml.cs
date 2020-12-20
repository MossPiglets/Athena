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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Athena
{
    /// <summary>
    /// Interaction logic for BaseWindow.xaml
    /// </summary>
    public partial class BookFormControl : UserControl
    {
        public BookFormControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Title { get; set; }

        public string ButtonContent { get; set; }
    }
}
