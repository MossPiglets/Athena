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
using Athena.Data.Series;
using Microsoft.EntityFrameworkCore;

namespace Athena.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddSeriesWindow.xaml
    /// </summary>
    public partial class AddSeriesWindow
    {
        public AddSeriesWindow() {
            InitializeComponent();
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e) {
            using var context = new ApplicationDbContext();
            if (!context.Series.Any(s => s.SeriesName.ToLower() == SeriesNameTextBox.Text.ToLower())) {
                context.Entry(new Series { SeriesName = SeriesNameTextBox.Text, Id = Guid.NewGuid() }).State = EntityState.Added;
                context.SaveChanges();
                this.Close();
            }
            else {
                SeriesExistsTextBlock.Visibility = Visibility.Visible;
            }
            
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Validation.GetHasError(SeriesNameTextBox);
        }    
    }
}
