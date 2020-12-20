using System.Windows.Controls;

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
