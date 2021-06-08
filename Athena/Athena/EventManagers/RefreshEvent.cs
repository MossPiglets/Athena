using System;
using System.Windows;

namespace Athena.EventManagers {
    class RefreshEvent {
        public event EventHandler OnDataBaseModified;
        private ApplicationDbContext ApplicationDbContext { get; set; }

        private void Start() {
            OnDataBaseModified += ListRefresh;
        }

        private void ListRefresh(object sender, EventArgs e) {
            MessageBox.Show("Działam!");
        }

        private void Update() { }
    }
}