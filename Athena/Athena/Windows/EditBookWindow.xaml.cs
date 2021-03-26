using System;
using System.Windows;
using System.Windows.Input;
using AdonisUI.Controls;
using Athena.Data;
using Athena.Data.Books;
using Microsoft.EntityFrameworkCore;

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
            Book bookModel = Mapper.Instance.Map<Book>(book);
            ContextTracker.AttackBookRelatedEntries(bookModel, context);
            context.Entry(bookModel).State = EntityState.Modified;
            context.SaveChanges();
            context.Entry(bookModel).State = EntityState.Detached;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}