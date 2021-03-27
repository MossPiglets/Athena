using System;
using System.Collections;
using System.Linq;
using Athena.Data.Books;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    public class ContextTracker {
        public static void AttackBookRelatedEntries(Book bookModel, ApplicationDbContext context) {
            AttachEntry(context, bookModel.Authors);
            AttachEntry(context, bookModel.Categories);
            AttachEntry(context, bookModel.PublishingHouse);
            AttachEntry(context, bookModel.StoragePlace);
            AttachEntry(context, bookModel.Series);
        }

        private static void AttachEntry(ApplicationDbContext context, object o) {
            if (o == null) return;

            try {
                if (o is IEnumerable enumerable) {
                    foreach (var entity in enumerable) {
                        context.Attach(entity);
                    }
                }
                else {
                    context.Attach(o);
                }
            }
            catch (InvalidOperationException) { }
        }
    }
}