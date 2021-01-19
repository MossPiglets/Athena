using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Athena.Data;
using Athena.Import.Extractors;
using Castle.Core.Internal;

namespace Athena.Import
{
    public static class ImportBookValidator
    {
        public static void CheckAuthors(ICollection<Author> authorsOfOneBook, List<Author> authors) {
            if (authorsOfOneBook.IsNullOrEmpty()) {
                return;
            }
            foreach (var author in authorsOfOneBook) {
                var query = authors.Where(a => a.FirstName == author.FirstName && a.LastName == author.LastName)
                    .Select(a => a)
                    .SingleOrDefault();
                if (query == null) {
                    throw new ExtractorException($"Cannot find author on ImportAuthorList, author [{author}]", $"{author.FirstName} {author.LastName}");
                }
            }
        }
    }
}
