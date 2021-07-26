using System;
using System.Collections.Generic;
using System.Linq;
using Athena.Data;
using Athena.Data.Books;
using Athena.Data.Categories;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;
using Athena.Data.StoragePlaces;
using Castle.Core.Internal;

namespace Athena.Import {
    public class DatabaseImporter : IDisposable {
        public void ImportFromSpreadsheet(string fileName) {
            if (IfDatabaseIsNotEmpty()) {
                throw new ImportException("Database is not empty. Remove sqlite file.");
            }

            IfDatabaseIsNotEmpty();

            var importData = new SpreadsheetDataImport(fileName);
            var authors = importData.ImportAuthorsList();
            ApplicationDbContext.Instance.Authors.AddRange(authors);
            var seriesInfoList = importData.ImportSeriesListInfo();
            var seriesList = seriesInfoList
                .GroupBy(a => a.SeriesName)
                .Select(a => a.First())
                .Where(a => !string.IsNullOrEmpty(a.SeriesName))
                .Select(a => a.ToSeries())
                .ToList();
            ApplicationDbContext.Instance.Series.AddRange(seriesList);
            var publishingHouses = importData.ImportPublishingHousesList();
            ApplicationDbContext.Instance.PublishingHouses.AddRange(publishingHouses);
            var categories = importData.ImportCategoriesList();
            ApplicationDbContext.Instance.Categories.AddRange(categories);
            var storagePlaces = importData.ImportStoragePlacesList();
            ApplicationDbContext.Instance.StoragePlaces.AddRange(storagePlaces);
            ApplicationDbContext.Instance.SaveChanges();
            var books = ImportBooksFromSpreadsheet(importData, authors, seriesList, publishingHouses, categories,
                storagePlaces);
            ApplicationDbContext.Instance.Books.AddRange(books);
            ApplicationDbContext.Instance.SaveChanges();
        }

        private List<Book> ImportBooksFromSpreadsheet(SpreadsheetDataImport importData, List<Author> authors,
            List<Series> seriesList, List<PublishingHouse> publishingHouses, List<Category> categories,
            List<StoragePlace> storagePlaces) {
            var books = importData.ImportBooksList();
            foreach (var book in books) {
                if (!book.Authors.IsNullOrEmpty()) {
                    var bookAuthors = book.Authors.ToList();
                    var collection = authors.Where(a
                        => bookAuthors.Any(b => b.FirstName == a.FirstName) &&
                           bookAuthors.Any(b => b.LastName == a.LastName));
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
            if (ApplicationDbContext.Instance.Books.Any() ||
                ApplicationDbContext.Instance.Authors.Any() ||
                ApplicationDbContext.Instance.Series.Any() ||
                ApplicationDbContext.Instance.Categories.Any() ||
                ApplicationDbContext.Instance.PublishingHouses.Any() ||
                ApplicationDbContext.Instance.StoragePlaces.Any()) {
                return true;
            }

            return false;
        }

        public void Dispose() {
            ApplicationDbContext.Instance.Dispose();
        }
    }
}