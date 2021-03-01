using System;
using System.Windows;
using System.Windows.Input;
using AdonisUI.Controls;
using Athena.Data;
using Athena.Data.Books;

namespace Athena.Windows {
    public partial class EditBookWindow {
        public EditBookWindow(Book book) {
            InitializeComponent();
            var bookControl = new BookFormControl("Edytuj książkę", "Zapisz", book);
            bookControl.ButtonCommand = new EditBookCommand();
            Content = bookControl;
        }
    }

    public class EditBookCommand : ICommand {
        public bool CanExecute(object parameter) {
            var validator = new BookViewValidator();
            var result = validator.Validate(parameter as BookView);
            return result.IsValid;;
        }

        public void Execute(object book) {
            using var context = new ApplicationDbContext();
            context.Books.Update(Mapper.Instance.Map<Book>(book));
            context.SaveChanges();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}