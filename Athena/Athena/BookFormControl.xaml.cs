using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Athena {

    public partial class BookFormControl : UserControl {
        public BookFormControl(string title, string buttonContent) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;

        }

        public string Title { get; set; }

        public string ButtonContent { get; set; }

        public ICommand ButtonCommand { get; set; }
    }
}