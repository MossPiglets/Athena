using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Athena.Data;
using Athena.Data.Books;
using Castle.Core.Internal;

namespace Athena {
    /// <summary>
    /// Interaction logic for BorrowForm.xaml
    /// </summary>
    public partial class BorrowForm {
        public BorrowForm(Book book) {
            InitializeComponent();
            this.DataContext = this;
            Title.Text = book.Title;
            var authors = ToAuthorsNames(book);
            if (!authors.IsNullOrEmpty()) {
                Author.Text = authors;
            }
        }

        public string ToAuthorsNames(Book book) {
            string authors = string.Empty;
            if (book.Authors.Count > 0) {
                for (int i = 0; i < book.Authors.Count; i++) {
                    var authorsList = book.Authors.ToList();
                    if (i == 0) {
                        authors = $"{authorsList[i].FirstName} {authorsList[i].LastName}";
                        continue;
                    }

                    authors = $"{authors} \n {authorsList[i].FirstName} {authorsList[i].LastName}";
                }
            }

            return authors;
        }
    }
}