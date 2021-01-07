using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using Athena.Data;
using OfficeOpenXml;

namespace Athena.Import {
    public class SpreadsheetDataImport: IDisposable {
        private ExcelPackage _package;
        private ExcelWorksheet _catalog;
        private ExcelWorksheet _categories;
        private ExcelWorksheet _storagePlaces;

        public SpreadsheetDataImport(string path) {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(new FileInfo(path));
            _catalog= _package.Workbook.Worksheets[0];
            _categories = _package.Workbook.Worksheets[1];
            _storagePlaces = _package.Workbook.Worksheets[2];
        }

        //public List<Book> ImportBooksList() {
        //    // extractory sa do regexow, beda wypluwac konkretny obiekty, ktore bede zczytywac z listy tutaj
        //    throw new NotImplementedException();
        //}

        public List<Author> ImportAuthorsList() {
            List<Author> authors = new List<Author>();
            var range = _catalog.Dimension.Rows;
            for (int i = 2; i < range + 1; i++) {
                var authorsOfOneBook = AuthorExtractor.Extract(_catalog.Cells[i, 2].Value.ToString());
                foreach (var author in authorsOfOneBook) {
                    if (!IsAuthorAlreadyInList(author, authors)) {
                        authors.Add(author);
                    }
                }
            }
            return authors;
        }

        private bool IsAuthorAlreadyInList(Author author, List<Author> authors) {
            return authors.Any(a => a.FirstName == author.FirstName && a.LastName == author.LastName);
        }

        public void Dispose() {
            _package.Dispose();
        }
    }
}