using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Athena.EventManagers;
using Microsoft.EntityFrameworkCore;

namespace Athena.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow
    {
        public AddAuthorWindow()
        {
            InitializeComponent();
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!ApplicationDbContext.Instance.Authors.Any(a => a.FirstName.ToLower() == AuthorFirstNameTextBox.Text.ToLower() && a.LastName.ToLower() == AuthorLastNameTextBox.Text.ToLower())) {
                var author = new Author {
                    FirstName = AuthorFirstNameTextBox.Text, LastName = AuthorLastNameTextBox.Text, Id = Guid.NewGuid()
                };
                ApplicationDbContext.Instance.Entry(author).State = EntityState.Added;
                ApplicationDbContext.Instance.SaveChanges();
                AuthorAdded?.Invoke(this, new EntityEventArgs<Author>{Entity = author});
                this.Close();
            }
            else
            {
                AuthorExistsTextBlock.Visibility = Visibility.Visible;
            }
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Validation.GetHasError(AuthorLastNameTextBox);
        }

        public event EventHandler<EntityEventArgs<Author>> AuthorAdded;
    }
}