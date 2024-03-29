﻿using System;
using System.Windows.Input;
using Athena.Data.Books;
using Athena.UserControls;
using Microsoft.EntityFrameworkCore;

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
        }

        public void Execute(object book) {
            Book bookModel = Mapper.Instance.Map<Book>(book);
            bookModel.Id = Guid.NewGuid();
            ContextTracker.AttackBookRelatedEntries(bookModel);
            ApplicationDbContext.Instance.Entry(bookModel).State = EntityState.Added;
            ApplicationDbContext.Instance.SaveChanges();
            ApplicationDbContext.Instance.ChangeTracker.Clear();
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}