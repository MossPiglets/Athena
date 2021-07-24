using System;
using FluentValidation;

namespace Athena.Data.Books {
    public class BookViewValidator : AbstractValidator<BookView> {
        public BookViewValidator() {
            RuleFor(book => book.Title)
                .NotEqual("")
                .WithMessage("Tytuł książki musi zostać podany.");
            RuleFor(book => book.PublishmentYear)
                .LessThanOrEqualTo(DateTime.Today.Year)
                .WithMessage($"Musi być mniejszy bądź równy {DateTime.Today.Year}");
        }
    }
}