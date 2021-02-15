using System;
using FluentValidation;

namespace Athena.Data.Books
{
    public class BookValidator: AbstractValidator<BookView>
    {
        public BookValidator() {
            RuleFor(book => book.Title)
                .NotNull();
            RuleFor(book => book.PublishmentYear)
                .LessThanOrEqualTo(DateTime.Today.Year);
        }
    }
}
