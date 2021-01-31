using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Athena.Data;

namespace Athena.Import {
    public class DataBaseImporter : IDisposable {
        ApplicationDbContext _context = new ApplicationDbContext();

        public void ImportFromSpreadsheet(string fileName) {
            CheckIfDatabaseIsEmpty();
            var importData = new SpreadsheetDataImport(fileName);
            var authors = importData.ImportAuthorsList();
            _context.Authors.AddRange(authors);
            var seriesList = importData.ImportSeriesList();
            _context.Series.AddRange(seriesList);
            var publishingHouses = importData.ImportPublishingHousesList();
            _context.PublishingHouses.AddRange(publishingHouses);
            var categories = importData.ImportCategoriesList();
            _context.Categories.AddRange(categories);
            var storagePlaces = importData.ImportStoragePlacesList();
            _context.StoragePlaces.AddRange(storagePlaces);
            var books = importData.ImportBooksList();

            // ma sprawdzac czy coś jest juz w bazie, jeśli tak - wywala wyjątek
            // używa klasy spreadsheet
            // wywołuje ją w przycisku import 
            // jak ktos nie wybierze pliku do importu to wybucha
        }

        private void CheckIfDatabaseIsEmpty() {
            if (_context.Books.Any() ||
                _context.Authors.Any() ||
                _context.Series.Any() ||
                _context.Categories.Any() ||
                _context.PublishingHouses.Any() ||
                _context.StoragePlaces.Any()) {
                throw new ImportException("Database is not empty. Remove sqlite file.");
            }
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}