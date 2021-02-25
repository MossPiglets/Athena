using System;
using System.Windows.Input;
using Athena.Data;
using Athena.Data.Books;

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
            var validator = new BookViewValidator();
            var result = validator.Validate(parameter as BookView);
            return result.IsValid;
            // return true;
        }

        public void Execute(object book) {
            using var context = new ApplicationDbContext();
            Book bookModel = Mapper.Instance.Map<Book>(book);
            bookModel.Id = Guid.NewGuid();
            context.Books.Add(bookModel);
            context.SaveChanges();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}