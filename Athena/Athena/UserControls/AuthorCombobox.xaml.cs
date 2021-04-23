using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    /// <summary>
    /// Interaction logic for AuthorAdding.xaml
    /// </summary>
    public partial class AuthorAdding : UserControl {
        public ObservableCollection<Author> Authors { get; set; }

        public AuthorAdding() {
            InitializeComponent();
            ApplicationDbContext.Instance.Authors.Load();
            Authors = ApplicationDbContext.Instance.Authors.Local.ToObservableCollection();
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e) {
            (this.Parent as StackPanel).Children.Remove(this);
        }
    }
}