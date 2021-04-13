using System;
using System.Linq;
using System.Windows;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow {
        public AddAuthorWindow() {
            InitializeComponent();
        }
        private void AddAuthorButton_Click(object sender, RoutedEventArgs e) {
            if (!ApplicationDbContext.Instance.Authors.Any(a => a.FirstName.ToLower() == AuthorFirstNameTextBox.Text.ToLower() && a.LastName.ToLower() == AuthorLastNameTextBox.Text.ToLower())) {
                ApplicationDbContext.Instance.Entry(new Author { FirstName = AuthorFirstNameTextBox.Text, LastName = AuthorLastNameTextBox.Text, Id = Guid.NewGuid() }).State = EntityState.Added;
                ApplicationDbContext.Instance.SaveChanges();
                this.Close();
            }
            else {
                AuthorExistsTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
