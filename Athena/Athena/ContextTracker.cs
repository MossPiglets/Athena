using Athena.Data.Books;
using Microsoft.EntityFrameworkCore;

namespace Athena
{
    public class ContextTracker
    {
        public static void AttackBookRelatedEntries(Book bookModel, ApplicationDbContext context) {
            context.AttachRange(bookModel.Authors);
            context.AttachRange(bookModel.Categories);
            if (bookModel.PublishingHouse != null) {
                context.Attach(bookModel.PublishingHouse);
            }

            if (bookModel.StoragePlace != null) {
                context.Attach(bookModel.StoragePlace);
            }

            if (bookModel.Series != null) {
                context.Attach(bookModel.Series);
            }
        }
    }
}
