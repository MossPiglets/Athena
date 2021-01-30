using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Athena.Data;

namespace Athena.Import {
    public class DataBaseImporter : IDisposable {
        ApplicationDbContext _db = new ApplicationDbContext();

        public void ImportFromSpreadsheet(string fileName) {
            CheckIfDatabaseIsEmpty();
            var importData = new SpreadsheetDataImport(fileName);
            var authors = importData.ImportAuthorsList();
            _db.Authors.AddRange(authors);
            var seriesList = importData.ImportSeriesList();
            _db.Series.AddRange(seriesList);
            var publishingHouses = importData.ImportPublishingHousesList();
            _db.PublishingHouses.AddRange(publishingHouses);
            var categories = importData.ImportCategoriesList();
            _db.Categories.AddRange(categories);
            var storagePlaces = importData.ImportStoragePlacesList();
            _db.StoragePlaces.AddRange(storagePlaces);
            var books = importData.ImportBooksList();

            // ma sprawdzac czy coś jest juz w bazie, jeśli tak - wywala wyjątek
            // używa klasy spreadsheet
            // wywołuje ją w przycisku import 
        }

        private void CheckIfDatabaseIsEmpty() {
            if (_db.Books.Any() ||
                _db.Authors.Any() ||
                _db.Series.Any() ||
                _db.Categories.Any() ||
                _db.PublishingHouses.Any() ||
                _db.StoragePlaces.Any()) {
                throw new ImportException("Database is not empty. Remove sqlite file.");
            }
        }

        public void Dispose() {
            _db.Dispose();
        }
    }
}