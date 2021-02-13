using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Athena.Data;
using Athena.Import.Extractors;
using Castle.Core.Internal;

namespace Athena.Import {
    public class DatabaseImporter : IDisposable {
        ApplicationDbContext _context = new ApplicationDbContext();

        public void ImportFromSpreadsheet(string fileName) {
            if (IfDatabaseIsNotEmpty()) {
                throw new ImportException("Database is not empty. Remove sqlite file.");
            }

            IfDatabaseIsNotEmpty();
            var importData = new SpreadsheetDataImport(fileName);
            var authors = importData.ImportAuthorsList();
            _context.Authors.AddRange(authors);
            var seriesInfoList = importData.ImportSeriesListInfo();
            var seriesList = seriesInfoList
                .GroupBy(a => a.SeriesName)
                .Select(a => a.First())
                .Where(a => !string.IsNullOrEmpty(a.SeriesName))
                .Select(a => a.ToSeries())
                .ToList();
            _context.Series.AddRange(seriesList);
            var publishingHouses = importData.ImportPublishingHousesList();
            _context.PublishingHouses.AddRange(publishingHouses);
            var categories = importData.ImportCategoriesList();
            _context.Categories.AddRange(categories);
            var storagePlaces = importData.ImportStoragePlacesList();
            _context.StoragePlaces.AddRange(storagePlaces);
            _context.SaveChanges();
            var books = ImportBooksFromSpreadsheet(importData, authors, seriesList, publishingHouses, categories,
                storagePlaces);
            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        private List<Book> ImportBooksFromSpreadsheet(SpreadsheetDataImport importData, List<Author> authors,
            List<Series> seriesList, List<PublishingHouse> publishingHouses, List<Category> categories,
            List<StoragePlace> storagePlaces) {
            var books = importData.ImportBooksList();
            foreach (var book in books) {
                if (!book.Authors.IsNullOrEmpty()) {
                    var bookAuthors = book.Authors.ToList();
                    var collection = authors.Where(a
                        => bookAuthors.Any(b => b.FirstName == a.FirstName) && bookAuthors.Any(b => b.LastName == a.LastName));
                    book.Authors = new List<Author>(collection);
                }

                if (book.Series != null) {
                    if (string.IsNullOrEmpty(book.Series.SeriesName)) {
                        book.Series = null;
                    }
                    else {
                        book.Series = seriesList.First(a => a.SeriesName == book.Series.SeriesName);
                    }
                }

                if (book.PublishingHouse != null) {
                    book.PublishingHouse =
                        publishingHouses.First(a => a.PublisherName == book.PublishingHouse.PublisherName);
                }

                if (!book.Categories.IsNullOrEmpty()) {
                    var bookCategories = book.Categories.ToList();
                    var collection = categories.Where(a => bookCategories.Select(c => c.Name).Contains(a.Name));
                    book.Categories = new List<Category>(collection);
                }

                if (book.StoragePlace != null) {
                    book.StoragePlace =
                        storagePlaces.First(a => a.StoragePlaceName == book.StoragePlace.StoragePlaceName);
                }
            }

            return books;
        }

        private bool IfDatabaseIsNotEmpty() {
            if (_context.Books.Any() ||
                _context.Authors.Any() ||
                _context.Series.Any() ||
                _context.Categories.Any() ||
                _context.PublishingHouses.Any() ||
                _context.StoragePlaces.Any()) {
                return true;
            }

            return false;
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}