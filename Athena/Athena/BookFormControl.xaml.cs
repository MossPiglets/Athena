using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena
{

    public partial class BookFormControl : UserControl {
        public BookFormControl(string title, string buttonContent) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
            Author author = new Author();
            author.FirstName = "Imię";
            author.LastName = "Nazwisko";
            //ApplicationDbContext.Authors.Add(author);
        }

        public Book Book { get; set; } = new Book();

        public string Title { get; set; }

        public string ButtonContent { get; set; }

        public ICommand ButtonCommand { get; set; }

        private void AddingAuthorCombobox(object sender, RoutedEventArgs e)
        {
            ComboBox newCB = new ComboBox();
            Button newBtn = new Button();
            DockPanel newDP = new DockPanel();
            //Setting Combobox properties
            newCB.IsEditable = true;
            var CBmargins = new Thickness(0, 7, 15, 0);
            newCB.Margin = CBmargins;
            newCB.Height = 22;
            //Setting button properties
            //newCB.ItemsSource = ApplicationDbContext.Authors;
            var BtnMargins = new Thickness(0,7,17,0);
            newBtn.Margin = BtnMargins;
            newBtn.Content = "-";
            newBtn.Width = 20;
            newBtn.Height = 20;
            newBtn.Click += new RoutedEventHandler(newBtn_Click);
            DockPanel.SetDock(newBtn, Dock.Right);
            //Adding to dockpanel
            newDP.ClipToBounds = false;
            newDP.Children.Add(newBtn);
            newDP.Children.Add(newCB);
            AuthorsStackPanel.Children.Add(newDP);
        }
        private void newBtn_Click(object sender, RoutedEventArgs e)

        {
            Button btn = sender as Button;
            
            AuthorsStackPanel.Children.Remove((UIElement)btn.Parent);
        }
    }
}