using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using Athena.Data;
using OfficeOpenXml;
using Serilog;
using Serilog.Core;

namespace Athena.Import {
    public class SpreadsheetDataImport : IDisposable {
        private ExcelPackage _package;
        private ExcelWorksheet _catalog;
        private ExcelWorksheet _categories;
        private ExcelWorksheet _storagePlaces;
        private Logger _log;

        public SpreadsheetDataImport(string fullFilePath) {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(new FileInfo(fullFilePath));
            _catalog = _package.Workbook.Worksheets[0];
            _categories = _package.Workbook.Worksheets[1];
            _storagePlaces = _package.Workbook.Worksheets[2];
            _log = new LoggerConfiguration().WriteTo.File($"./logs/ImportLog_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        //public List<Book> ImportBooksList() {
        //    // extractory sa do regexow, beda wypluwac konkretny obiekty, ktore bede zczytywac z listy tutaj
        //    throw new NotImplementedException();
        //}

        public List<Author> ImportAuthorsList() {
            List<Author> authors = new List<Author>();
            var range = 1595;
            for (int i = 2; i < range + 1; i++) {
                List<Author> authorsOfOneBook;
                try {
                    authorsOfOneBook = AuthorExtractor.Extract(_catalog.Cells[i, 2].Value?.ToString());
                }
                catch (ExtractorException e) {
                    _log.Error($"Author Extract Error: [{e.Text}]");
                    continue;
                }

                //
                foreach (var author in authorsOfOneBook) {
                    if (!IsAuthorAlreadyInList(author, authors)) {
                        authors.Add(author);
                    }
                }
            }
            //todo
            // tutaj zrobić disting z użyciem GroupBy zamiast foreacha wyżej #spid
            return authors;
        }

        private bool IsAuthorAlreadyInList(Author author, List<Author> authors) {
            return authors.Any(a => a.FirstName == author.FirstName && a.LastName == author.LastName);
        }

        public void Dispose() {
            _package.Dispose();
            _log.Dispose();
        }
    }
}