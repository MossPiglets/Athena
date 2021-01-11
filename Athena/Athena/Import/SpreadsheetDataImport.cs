using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using Athena.Data;
using Athena.Import.Extractors;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
                    index++;
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

        public List<Series> ImportSeriesList() {
            var index = 2;
            List<Series> seriesList = new List<Series>();
            while (_catalog.Cells[index, 1].Value != null) {
                Series series;
                try {
                    series = SeriesExtractor.Extract(_catalog.Cells[index, 3].Value?.ToString());
                }
                catch (ExtractorException e) {
                    _log.Error($"Series Extract Error: [{e.Text}]");
                    index++;
                    continue;
                }

                seriesList.Add(series);
                index++;
            }

            var seriesWithoutDoubles = seriesList
                .GroupBy(a => new { a.SeriesName, a.VolumeNumber })
                .Select(a => a.First())
                .ToList();
            return seriesWithoutDoubles;
        }

        public List<PublishingHouse> ImportPublishingHousesList() {
            var index = 2;
            List<PublishingHouse> publishingHousesList = new List<PublishingHouse>();
            while (_catalog.Cells[index, 1].Value != null) {
                var publishingHouse = PublishingHouseExtractor.Extract(_catalog.Cells[index, 4].Value?.ToString());
                publishingHousesList.Add(publishingHouse);
                index++;
            }

            var seriesWithoutDoubles = publishingHousesList
                .GroupBy(a => a.PublisherName)
                .Select(a => a.First())
                .ToList();
            return seriesWithoutDoubles;
        }

        public void Dispose() {
            _package.Dispose();
            _log.Dispose();
        }
    }
}