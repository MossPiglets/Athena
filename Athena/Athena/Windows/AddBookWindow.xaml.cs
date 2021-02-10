using System;
using System.Windows.Input;
using Athena.Data;

namespace Athena.Windows {
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow {
        public AddBookWindow() {
            InitializeComponent();
            var bookControl = new BookFormControl("Dodaj książkę", "Dodaj", new Book());
            bookControl.ButtonCommand = new AddBookCommand();
            this.Content = bookControl;
        }
    }


    public class AddBookCommand : ICommand {
        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object book) {
            using var context = new ApplicationDbContext();
            Book bookModel = book as Book;
            bookModel.Id = Guid.NewGuid();
            context.Books.Add(bookModel);
            context.SaveChanges();
        }

        public event EventHandler CanExecuteChanged;
    }
}