using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Athena.Data;
using Athena.Data.Books;
using Athena.Data.Series;
using Athena.Data.SpreadsheetData;
using Athena.Import.Extractors;
using OfficeOpenXml;
using Serilog;
using Serilog.Core;
using Author = Athena.Data.Author;

namespace Athena.Import {
    public class SpreadsheetDataImport : IDisposable {
        private string _fullFilePath;
        private Logger _log;
        private List<SpreadsheetCatalogData> _spreadsheetCatalogDataList = null;
        private List<SpreadsheetCategoryData> _spreadsheetCategoryDataList = null;
        private List<SpreadsheetStoragePlaceData> _spreadsheetStoragePlaceDataList = null;

        public IReadOnlyList<SpreadsheetCatalogData> CatalogData {
            get {
                if (_spreadsheetCatalogDataList == null) {
                    LoadData();
                }

                return _spreadsheetCatalogDataList.AsReadOnly();
            }
        }

        public IReadOnlyList<SpreadsheetCategoryData> CategoryData {
            get {
                if (_spreadsheetCategoryDataList == null) {
                    LoadData();
                }

                return _spreadsheetCategoryDataList.AsReadOnly();
            }
        }

        public IReadOnlyList<SpreadsheetStoragePlaceData> StoragePlaceData {
            get {
                if (_spreadsheetStoragePlaceDataList == null) {
                    LoadData();
                }

                return _spreadsheetStoragePlaceDataList.AsReadOnly();
            }
        }


        public SpreadsheetDataImport(string fullFilePath) {
            _fullFilePath = fullFilePath;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _log = new LoggerConfiguration().WriteTo.File("./logs/ImportLog_.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LoadData() {
            using var package = new ExcelPackage(new FileInfo(_fullFilePath));
            var catalog = package.Workbook.Worksheets[0];
            var categories = package.Workbook.Worksheets[1];
            var storagePlaces = package.Workbook.Worksheets[2];
            _spreadsheetCatalogDataList = new List<SpreadsheetCatalogData>();
            _spreadsheetCategoryDataList = new List<SpreadsheetCategoryData>();
            _spreadsheetStoragePlaceDataList = new List<SpreadsheetStoragePlaceData>();

            var catalogRowNumber = 2;

            while (catalog.Cells[catalogRowNumber, 1].Value != null) {
                var catalogData = new SpreadsheetCatalogData {
                    Title = catalog.Cells[catalogRowNumber, 1].Value.ToString(),
                    Author = catalog.Cells[catalogRowNumber, 2].Value?.ToString(),
                    Series = catalog.Cells[catalogRowNumber, 3].Value?.ToString(),
                    PublishingHouse = catalog.Cells[catalogRowNumber, 4].Value?.ToString(),
                    Year = catalog.Cells[catalogRowNumber, 5].Value?.ToString(),
                    Town = catalog.Cells[catalogRowNumber, 6].Value?.ToString(),
                    ISBN = catalog.Cells[catalogRowNumber, 7].Value?.ToString(),
                    Language = catalog.Cells[catalogRowNumber, 8].Value.ToString(),
                    StoragePlace = catalog.Cells[catalogRowNumber, 9].Value?.ToString(),
                    Comment = catalog.Cells[catalogRowNumber, 10].Value?.ToString(),
                    Category = catalog.Cells[catalogRowNumber, 2].Style.Fill.BackgroundColor.Rgb
                };
                _spreadsheetCatalogDataList.Add(catalogData);
                catalogRowNumber++;
            }

            var categoryRowNumber = 2;

            while (categories.Cells[categoryRowNumber, 1].Value != null) {
                var categoryData = new SpreadsheetCategoryData {
                    Colour = categories.Cells[categoryRowNumber, 1].Style.Fill.BackgroundColor.Rgb,
                    Name = categories.Cells[categoryRowNumber, 2].Value.ToString()
                };
                _spreadsheetCategoryDataList.Add(categoryData);
                categoryRowNumber++;
            }

            var storagePlaceRowNumber = 2;
            while (storagePlaces.Cells[storagePlaceRowNumber, 1].Value != null) {
                var storagePlaceData = new SpreadsheetStoragePlaceData {
                    Name = storagePlaces.Cells[storagePlaceRowNumber, 1].Value.ToString(),
                    Comment = storagePlaces.Cells[storagePlaceRowNumber, 2].Value.ToString()
                };
                _spreadsheetStoragePlaceDataList.Add(storagePlaceData);
                storagePlaceRowNumber++;
            }
        }

        public List<Book> ImportBooksList() {
            var authors = ImportAuthorsList();
            var seriesInfos = ImportSeriesListInfo();
            var publishingHouses = ImportPublishingHousesList();
            var storagePlaces = ImportStoragePlacesList();
            var categories = ImportCategoriesList();

            var seriesList = seriesInfos
                .GroupBy(a => a.SeriesName)
                .Select(a => a.First())
                .Where(a => !string.IsNullOrEmpty(a.SeriesName))
                .Select(a => a.ToSeries())
                .ToList();
            List<Book> books = new List<Book>();
            foreach (var spreadsheetData in CatalogData) { }

            foreach (var spreadsheetCatalogData in CatalogData) {
                var bookCategories = new List<Category>() {
                    CategoryExtractor.Extract(spreadsheetCatalogData.Category)
                };
                bookCategories = bookCategories.Where(a => a != null).ToList();
                var bookSeriesInfo = SeriesInfoExtractor.Extract(spreadsheetCatalogData.Series);

                var book = new Book {
                    Id = Guid.NewGuid(),
                    Title = TitleExtractor.Extract(spreadsheetCatalogData.Title),
                    Authors = AuthorExtractor.Extract(spreadsheetCatalogData.Author),
                    Series = bookSeriesInfo?.ToSeries(),
                    PublishingHouse = PublishingHouseExtractor.Extract(spreadsheetCatalogData.PublishingHouse),
                    PublishmentYear = YearExtractor.Extract(spreadsheetCatalogData.Year),
                    ISBN = IsbnExtractor.Extract(spreadsheetCatalogData.ISBN),
                    Language = LanguageExtractor.Extract(spreadsheetCatalogData.Language),
                    StoragePlace = StoragePlaceExtractor.Extract(spreadsheetCatalogData.StoragePlace),
                    Comment = CommentExtractor.Extract(spreadsheetCatalogData.Comment),
                    Categories = bookCategories,
                    VolumeNumber = bookSeriesInfo?.VolumeNumber
                };
                ImportBookValidator.CheckAuthors(authors, book.Authors);
                ImportBookValidator.CheckSeries(seriesList, book.Series);
                ImportBookValidator.CheckPublishingHouse(publishingHouses, book.PublishingHouse);
                ImportBookValidator.CheckStoragePlace(storagePlaces, book.StoragePlace);
                ImportBookValidator.CheckCategory(categories, book.Categories);
                books.Add(book);
            }

            return books;
        }


        public List<Author> ImportAuthorsList() {
            List<Author> authors = new List<Author>();
            foreach (var spreadsheetData in CatalogData) {
                List<Author> authorsOfOneBook;
                try {
                    authorsOfOneBook = AuthorExtractor.Extract(spreadsheetData.Author);
                }
                catch (ExtractorException e) {
                    _log.Error($"Author Extract Error: [{e.Text}]");
                    continue;
                }

                authors.AddRange(authorsOfOneBook);
            }

            var authorWithoutDoubles = authors
                .GroupBy(a => new { a.FirstName, a.LastName })
                .Select(a => a.First())
                .ToList();
            return authorWithoutDoubles;
        }

        public List<SeriesInfo> ImportSeriesListInfo() {
            List<SeriesInfo> seriesInfoList = new List<SeriesInfo>();
            foreach (var spreadsheetData in CatalogData) {
                SeriesInfo seriesInfo;
                try {
                    seriesInfo = SeriesInfoExtractor.Extract(spreadsheetData.Series);
                }
                catch (ExtractorException e) {
                    _log.Error($"Series Extract Error: [{e.Text}]");
                    continue;
                }

                if (seriesInfo != null) {
                    seriesInfoList.Add(seriesInfo);
                }
            }

            var seriesInfoWithoutDoubles = seriesInfoList
                .GroupBy(a => new { a.SeriesName, a.VolumeNumber })
                .Select(a => a.First())
                .ToList();
            return seriesInfoWithoutDoubles;
        }

        public List<PublishingHouse> ImportPublishingHousesList() {
            List<PublishingHouse> publishingHousesList = new List<PublishingHouse>();
            foreach (var spreadsheetData in CatalogData) {
                var publishingHouse = PublishingHouseExtractor.Extract(spreadsheetData.PublishingHouse);
                publishingHousesList.Add(publishingHouse);
            }

            var seriesWithoutDoubles = publishingHousesList
                .GroupBy(a => a.PublisherName)
                .Select(a => a.First())
                .ToList();
            return seriesWithoutDoubles;
        }

        public List<StoragePlace> ImportStoragePlacesList() {
            List<StoragePlace> storagePlaces = new List<StoragePlace>();
            foreach (var spreadsheetStoragePlaceData in StoragePlaceData) {
                var storagePlace = StoragePlaceExtractor.Extract(spreadsheetStoragePlaceData.Name,
                    spreadsheetStoragePlaceData.Comment);
                if (storagePlace != null) {
                    storagePlaces.Add(storagePlace);
                }
            }

            foreach (var spreadsheetCatalogData in CatalogData) {
                var storagePlace = StoragePlaceExtractor.Extract(spreadsheetCatalogData.StoragePlace);
                if (storagePlace != null) {
                    storagePlaces.Add(storagePlace);
                }
            }

            var storagePlacesWithoutDoubles = storagePlaces
                .GroupBy(a => a.StoragePlaceName)
                .Select(a =>
                    a.FirstOrDefault(b => !string.IsNullOrEmpty(b.Comment)) ?? a.First())
                .ToList();

            return storagePlacesWithoutDoubles;
        }

        public List<Category> ImportCategoriesList() {
            List<Category> categories = new List<Category>();
            foreach (var spreadsheetCategoryData in CategoryData) {
                var category = CategoryExtractor.Extract(spreadsheetCategoryData.Colour);
                if (category != null) {
                    categories.Add(category);
                }
            }

            return categories;
        }

        public void Dispose() {
            _log.Dispose();
        }
    }
}