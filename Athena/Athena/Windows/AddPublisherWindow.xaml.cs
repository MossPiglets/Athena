using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data.PublishingHouses;
using Microsoft.EntityFrameworkCore;

namespace Athena.Windows {
    /// <summary>
    /// Logika interakcji dla klasy AddPublisherWindow.xaml
    /// </summary>
    public partial class AddPublisherWindow {
        public AddPublisherWindow() {
            InitializeComponent();
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e) {
            using var context = new ApplicationDbContext();
            if (!context.PublishingHouses.Any(s => s.PublisherName.ToLower() == PublisherNameTextBox.Text.ToLower())) {
                context.Entry(new PublishingHouse() {PublisherName = PublisherNameTextBox.Text, Id = Guid.NewGuid()})
                    .State = EntityState.Added;
                context.SaveChanges();
                this.Close();
            }
            else {
                PublisherExistsTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Validation.GetHasError(PublisherNameTextBox);
        }
    }
}