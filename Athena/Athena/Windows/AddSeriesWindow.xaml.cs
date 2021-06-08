using Athena.Data.Series;
using Athena.EventManagers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            if (!ApplicationDbContext.Instance.Series.Any(s => s.SeriesName.ToLower() == SeriesNameTextBox.Text.ToLower())) {
                var series = new Series { SeriesName = SeriesNameTextBox.Text, Id = Guid.NewGuid() };
                
                ApplicationDbContext.Instance.Entry(new Series { SeriesName = SeriesNameTextBox.Text, Id = Guid.NewGuid() }).State = EntityState.Added;
                ApplicationDbContext.Instance.SaveChanges();
                SeriesAdded?.Invoke(this, new EntityAddedEventArgs<Series> { Entity = series});
                this.Close();
            }
            else {
                SeriesExistsTextBlock.Visibility = Visibility.Visible;
            }

        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Validation.GetHasError(SeriesNameTextBox);
        }

        public event EventHandler<EntityAddedEventArgs<Series>> SeriesAdded;

    }
}
