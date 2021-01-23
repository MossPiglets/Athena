using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;
using Athena.Windows;

namespace Athena {

    public partial class BookFormControl : UserControl {
        public BookFormControl(string title, string buttonContent) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
        }

        public Book Book { get; set; } = new Book();

        public string Title { get; set; }

        public string ButtonContent { get; set; }

        public ICommand ButtonCommand { get; set; }

        private void AddSeries_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddSeriesWindow();
            window.Show();
        }
    }
}