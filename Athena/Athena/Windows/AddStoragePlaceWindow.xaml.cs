using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Athena.Data;
using System;
using System.Windows;

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

        private void AddStoragePlaceButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using var context = new ApplicationDbContext();
            if (!context.StoragePlaces.Any(a => a.StoragePlaceName.ToLower() == StoragePlaceTextBox.Text.ToLower()))
            {
                context.Entry(new StoragePlace { StoragePlaceName = StoragePlaceTextBox.Text, Id = Guid.NewGuid() }).State = EntityState.Added;
                context.SaveChanges();

                this.Close();
            }

            else
            {
                StoragePlaceExistsTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
