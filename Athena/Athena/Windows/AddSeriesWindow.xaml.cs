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
using Athena.Data;
using System.Linq;

namespace Athena.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddSeriesWindow.xaml
    /// </summary>
    public partial class AddSeriesWindow
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public AddSeriesWindow()
        {
            InitializeComponent();
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!_context.Series.Any(s => s.SeriesName == SeriesNameTextBox.Text))
            {
                _context.Series.Add(new Data.Series.Series { SeriesName = SeriesNameTextBox.Text });
                _context.SaveChanges();
            }
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(SeriesNameTextBox);
        }    
    }
}
