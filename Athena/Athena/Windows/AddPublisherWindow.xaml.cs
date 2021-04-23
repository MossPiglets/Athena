using System;
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
        public PublishingHouseView PublishingHouseView { get; set; }

        public AddPublisherWindow() {
            InitializeComponent();
            this.DataContext = this;
            PublishingHouseView = new PublishingHouseView();
        }

        private void AddPublisherToDataBase_OnClick(object sender, RoutedEventArgs e) {
            PublishingHouseView.Id = Guid.NewGuid();
            ApplicationDbContext.Instance.Entry(Mapper.Instance.Map<PublishingHouse>(PublishingHouseView)).State = EntityState.Added;
            ApplicationDbContext.Instance.SaveChanges();
            this.Close();
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(PublisherNameTextBox);
        }
    }
}