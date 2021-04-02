using System;
using System.Windows;
using Athena.Data.PublishingHouses;
using Microsoft.EntityFrameworkCore;

namespace Athena.Windows {
    /// <summary>
    /// Logika interakcji dla klasy AddPublisherWindow.xaml
    /// </summary>
    public partial class AddPublisherWindow {
        public PublishingHouseView PublishingHouseView { get; set; }
        private ApplicationDbContext Context { get; set; }

        public AddPublisherWindow() {
            InitializeComponent();
            PublishingHouseView = new PublishingHouseView();
            Context = new ApplicationDbContext();
        }

        private void AddPublisherToDataBase_OnClick(object sender, RoutedEventArgs e) {
            PublishingHouseView.Id = Guid.NewGuid();
            PublishingHouseView.PublisherName = PublisherNameTextBox.Text;
            Context.Entry(Mapper.Instance.Map<PublishingHouse>(PublishingHouseView)).State = EntityState.Added;
            Context.SaveChanges();
            this.Close();
        }
    }
}