using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena
{
    /// <summary>
    /// Interaction logic for AuthorAdding.xaml
    /// </summary>
    public partial class AuthorAdding : UserControl
    {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Author> Authors { get; set; }

        public Action Delete;
        public AuthorAdding()
        {
            InitializeComponent();
            ApplicationDbContext = new ApplicationDbContext();
            ApplicationDbContext.Authors.Load();
            Authors = ApplicationDbContext.Authors.Local.ToObservableCollection();
        }


        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as StackPanel).Children.Remove(this);
        }
    }
}
