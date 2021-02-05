using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Athena.Data;
using Castle.Core.Internal;

namespace Athena.Import {
    public class DataBaseImporter : IDisposable {
        ApplicationDbContext _context = new ApplicationDbContext();

        public void ImportFromSpreadsheet(string fileName) {
            if (IfDatabaseIsNotEmpty()) {
                throw new ImportException("Database is not empty. Remove sqlite file.");
            }

            IfDatabaseIsNotEmpty();
            var importData = new SpreadsheetDataImport(fileName);
            var authors = importData.ImportAuthorsList();
            _context.Authors.AddRange(authors);
            _context.SaveChanges();
            var seriesList = importData.ImportSeriesList();
            _context.Series.AddRange(seriesList);
            _context.SaveChanges();
            var publishingHouses = importData.ImportPublishingHousesList();
            _context.PublishingHouses.AddRange(publishingHouses);
            _context.SaveChanges();
            var categories = importData.ImportCategoriesList();
            _context.Categories.AddRange(categories);
            _context.SaveChanges();
            var storagePlaces = importData.ImportStoragePlacesList();
            _context.StoragePlaces.AddRange(storagePlaces);
            _context.SaveChanges();
            var books = ImportBooksFromSpreadsheet(importData, authors, seriesList, publishingHouses, categories,
                storagePlaces);
            foreach (var book in books) {
                _context.Books.Add(book);
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }

        private List<Book> ImportBooksFromSpreadsheet(SpreadsheetDataImport importData, List<Author> authors,
            List<Series> seriesList, List<PublishingHouse> publishingHouses, List<Category> categories,
            List<StoragePlace> storagePlaces) {
            var books = importData.ImportBooksList();
            foreach (var book in books) {
                if (!book.Authors.IsNullOrEmpty()) {
                    for (int i = 0; i < book.Authors.Count; i++) {
                        var author = book.Authors.ToList()[i];
                        author = authors.First(a => a.FirstName == author.FirstName && a.LastName == author.LastName);
                    }
                }

                if (book.Series != null) {
                    var series = book.Series;
                    series = seriesList.First(a
                        => a.SeriesName == series.SeriesName && a.VolumeNumber == series.VolumeNumber);
                }

                if (book.PublishingHouse != null) {
                    var publishingHouse = book.PublishingHouse;
                    publishingHouse = publishingHouses.First(a => a.PublisherName == publishingHouse.PublisherName);
                }

                if (!book.Categories.IsNullOrEmpty()) {
           
                    var bookCategories = book.Categories.ToList();
                    var collection = categories.Where(a => bookCategories.Select(c => c.Name).Contains(a.Name));
                    book.Categories = new List<Category>(collection);
                }

                if (book.StoragePlace != null) {
                    var storagePlace = book.StoragePlace;
                    storagePlace = storagePlaces.First(a => a.StoragePlaceName == storagePlace.StoragePlaceName);
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