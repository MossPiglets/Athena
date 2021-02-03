using Athena.Data;
using System.Collections.Generic;
using System.Windows;
using Athena.Windows;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace Athena {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow {
		private ApplicationDbContext ApplicationDbContext { get; set; }
        public ObservableCollection<Book> Books { get; set; }
		public MainWindow() {
			InitializeComponent();
			this.DataContext = this;
			//BookList.ItemsSource =  new List<Book>();

			Book book = new Book();
			Author author = new Author() { FirstName = "Test", LastName = "Testowy" };
			book.Title = "Tyty³ testowy";


			ApplicationDbContext = new ApplicationDbContext();
			//book.Authors.Add(author);
			ApplicationDbContext.Books.Add(book);
			ApplicationDbContext.Books.Load();
			Books = ApplicationDbContext.Books.Local.ToObservableCollection();
		}

		private void AddBook_OnClick(object sender, RoutedEventArgs e) {
			new AddBookWindow().Show();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			var w = new AddBookWindow();
			w.Show();
        }
    }
}