using System;
using System.Linq;
using System.Windows.Input;
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
            return result.IsValid;
            ;
        }

        public void Execute(object book) {
            using var context = new ApplicationDbContext();
            Book bookModel = Mapper.Instance.Map<Book>(book);
            ContextTracker.AttackBookRelatedEntries(bookModel, context);
            var bookFromDb = context.Books
                .Include(a => a.Authors)
                .Include(a => a.Categories)
                .Include(a => a.PublishingHouse)
                .Include(a => a.Series)
                .Include(a => a.StoragePlace)
                .Single(a => a.Id == bookModel.Id);
            Mapper.Instance.Map(bookModel, bookFromDb);
            context.SaveChanges();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}