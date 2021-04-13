using System;
using System.Collections;
using System.Linq;
using Athena.Data.Books;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    public class ContextTracker {
        public static void AttackBookRelatedEntries(Book bookModel) {
            AttachEntry(bookModel.Authors);
            AttachEntry(bookModel.Categories);
            AttachEntry(bookModel.PublishingHouse);
            AttachEntry(bookModel.StoragePlace);
            AttachEntry(bookModel.Series);
        }

        private static void AttachEntry( object o) {
            if (o == null) return;

            try {
                if (o is IEnumerable enumerable) {
                    foreach (var entity in enumerable) {
                        ApplicationDbContext.Instance.Attach(entity);
                    }
                }
                else {
                    ApplicationDbContext.Instance.Attach(o);
                }
            }
            catch (InvalidOperationException) { }
        }
    }
}