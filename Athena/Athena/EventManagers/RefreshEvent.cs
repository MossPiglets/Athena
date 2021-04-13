using System.Collections.ObjectModel;
using System.Linq;
using System;
using Athena.Data;
using Athena.Data.Books;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Athena.EventManagers
{
    class RefreshEvent {
        public event EventHandler OnDataBaseModified;
        private ApplicationDbContext ApplicationDbContext { get; set; }
        private void Start()
        {
            OnDataBaseModified += ListRefresh;
        }
        private void ListRefresh(object sender, EventArgs e)
        {
            MessageBox.Show("Działam!");
        }
        private void Update()
        {
            if (ApplicationDbContext.WasModified() == true)
            {
                OnDataBaseModified?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
