using System;
using System.Windows;
using System.Windows.Input;
using AdonisUI.Controls;
using Athena.Data;

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
            return true;
        }

        public void Execute(object book) {
            using var context = new ApplicationDbContext();
            context.Books.Update(book as Book);
            context.SaveChanges();
        }

        public event EventHandler CanExecuteChanged;
    }
}