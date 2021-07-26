using System.Windows;
using System.Windows.Controls;
using Athena.Data.Categories;
using Athena.EnumLocalizations;

namespace Athena.UserControls {
    /// <summary>
    /// Interaction logic for CategoryAdding.xaml
    /// </summary>
    public partial class CategoryAdding : UserControl {
        public CategoryAdding() {
            InitializeComponent();
            CategoryComboBox.ItemsSource = EnumSorter.GetSortedByDescriptions<CategoryName>();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            (this.Parent as StackPanel).Children.Remove(this);
        }
    }
}