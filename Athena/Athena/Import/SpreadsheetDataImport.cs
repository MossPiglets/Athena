using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Serilog;
using Serilog.Core;
using Author = Athena.Data.Author;

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
            _log = new LoggerConfiguration().WriteTo.File("./logs/ImportLog_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public List<Author> ImportAuthorsList() {
            List<Author> authors = new List<Author>();
            var index = 2;
            while (_catalog.Cells[index, 1].Value != null) {
                List<Author> authorsOfOneBook;
                try {
                    authorsOfOneBook = AuthorExtractor.Extract(_catalog.Cells[index, 2].Value?.ToString());
                }
                catch (ExtractorException e) {
                    _log.Error($"Author Extract Error: [{e.Text}]");
                    continue;
                }

                authors.AddRange(authorsOfOneBook);
                index++;
            }

            var authorWithoutDoubles = authors
                .GroupBy(a => new { a.FirstName, a.LastName })
                .Select(a => a.First())
                .ToList();
            return authorWithoutDoubles;
        }
        //todo
        //ImportSeries


        public void Dispose() {
            _package.Dispose();
            _log.Dispose();
        }
    }
}