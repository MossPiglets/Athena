using Athena.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Athena.Windows
{
    public partial class BorrowedBooksListWindow
    {
        public BorrowedBooksListWindow()
        {
            InitializeComponent();
            BorrowedBookList.ItemsSource = new List<Borrowing>() {new Borrowing()};
        }


    }
}
