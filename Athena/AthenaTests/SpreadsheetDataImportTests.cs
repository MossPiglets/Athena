﻿using System;
using System.Linq;
using Athena.Import;
using AthenaTests.Helpers;
using AthenaTests.Helpers.Data.TestExcel;
using FluentAssertions;
using NUnit.Framework;
using OfficeOpenXml;

namespace AthenaTests {
    public class SpreadsheetDataImportTests {
        [OneTimeSetUp]
        public void Setup() {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        [Test]
        public void SpreadsheetDataImport_ShouldCreateExcelFile() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            // Act
            Action act = () => new SpreadsheetDataImport(data.FileName);
            // Assert
            act.Should().NotThrow();
            package.File.Delete();
        }

        [Test]
        public void ImportAuthorsList_ShouldReturnAuthorsList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var authors = dataImport.ImportAuthorsList();
            // Assert
            authors.Should().HaveSameCount(data.CatalogTestsDataList);
            for (int i = 0; i < authors.Count; i++) {
                var author = authors[i];
                var catalogData = data.CatalogTestsDataList[i];
                author.Id.Should().NotBeEmpty();
                author.FirstName.Should().Be(catalogData.AuthorFirstName);
                author.LastName.Should().Be(catalogData.AuthorLastName);
            }

            package.File.Delete();
        }

        [Test]
        public void ImportAuthorsList_Duplicates_ShouldReturnAuthorsListWithoutDuplicates() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Add(data.CatalogTestsDataList[0]);
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var authors = dataImport.ImportAuthorsList();
            // Assert
            authors.Should().HaveCount(data.CatalogTestsDataList.Count - 1);
            authors.Should().OnlyHaveUniqueItems();

            package.File.Delete();
        }

        [Test]
        public void ImportAuthorList_EmptyExcel_ShouldReturnEmptyAuthorsList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var authors = dataImport.ImportAuthorsList();
            // Assert
            authors.Should().BeEmpty();

            package.File.Delete();
        }

        [Test]
        public void ImportSeriesList_ShouldReturnSeriesList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var seriesList = dataImport.ImportSeriesListInfo();
            // Assert
            seriesList.Should().HaveSameCount(data.CatalogTestsDataList);
            for (int i = 0; i < seriesList.Count; i++) {
                var series = seriesList[i];
                var catalogData = data.CatalogTestsDataList[i];
                series.Id.Should().NotBeEmpty();
                series.SeriesName.Should().Be(catalogData.SeriesName);
                series.VolumeNumber.Should().Be(catalogData.VolumeNumber);
            }

            package.File.Delete();
        }

        [Test]
        public void ImportSeriesList_Duplicates_ShouldReturnSeriesListWithoutDuplicates() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Add(data.CatalogTestsDataList[0]);
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var seriesList = dataImport.ImportSeriesListInfo();
            // Assert
            seriesList.Should().HaveCount(data.CatalogTestsDataList.Count - 1);
            seriesList.Should().OnlyHaveUniqueItems();

            package.File.Delete();
        }

        [Test]
        public void ImportSeriesList_EmptyExcel_ShouldReturnEmptySeriesList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var seriesList = dataImport.ImportSeriesListInfo();
            // Assert
            seriesList.Should().BeEmpty();

            package.File.Delete();
        }

        [Test]
        public void ImportPublishingHousesList_ShouldReturnPublishingHousesList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var publishingHouses = dataImport.ImportPublishingHousesList();
            // Assert
            publishingHouses.Should().HaveSameCount(data.CatalogTestsDataList);
            for (int i = 0; i < publishingHouses.Count; i++) {
                var publishingHouse = publishingHouses[i];
                var catalogData = data.CatalogTestsDataList[i];
                publishingHouse.Id.Should().NotBeEmpty();
                publishingHouse.PublisherName.Should().Be(catalogData.PublishingHouse);
            }

            package.File.Delete();
        }

        [Test]
        public void ImportPublishingHousesList_Duplicates_ShouldReturnPublishingHouseListWithoutDuplicates() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Add(data.CatalogTestsDataList[0]);
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var publishingHouses = dataImport.ImportPublishingHousesList();
            // Assert
            publishingHouses.Should().HaveCount(data.CatalogTestsDataList.Count - 1);
            publishingHouses.Should().OnlyHaveUniqueItems();

            package.File.Delete();
        }

        [Test]
        public void ImportPublishingHouseList_EmptyExcel_ShouldReturnEmptyPublishingHouseList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var publishingHouses = dataImport.ImportPublishingHousesList();
            // Assert
            publishingHouses.Should().BeEmpty();

            package.File.Delete();
        }

        [Test]
        public void ImportStoragePlacesList_ShouldReturnStoragePlacesList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().HaveCount(data.StoragePlaceTestsDataList.Count + data.CatalogTestsDataList.Count);
            var catalogData = data.CatalogTestsDataList;
            var storagePlaceData = data.StoragePlaceTestsDataList;
            foreach (var storagePlace in storagePlaces) {
                storagePlace.Id.Should().NotBeEmpty();
            }
            storagePlaces.Should().OnlyContain(a => 
                catalogData.Any(b => b.StoragePlace == a.StoragePlaceName)||
                storagePlaceData.Any(b => b.StoragePlaceName == a.StoragePlaceName));
            package.File.Delete();
        }
        [Test]
        public void ImportStoragePlacesList_Duplicates_ShouldReturnStoragePlacesListWithoutDuplicates() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Add(data.CatalogTestsDataList[0]);
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().HaveCount(data.CatalogTestsDataList.Count + data.StoragePlaceTestsDataList.Count - 1);
            storagePlaces.Should().OnlyHaveUniqueItems();

            package.File.Delete();
        }
        [Test]
        public void ImportStoragePlacesList_BothEmptyExcel_ShouldReturnEmptyStoragePlacesList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            data.StoragePlaceTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().BeEmpty();

            package.File.Delete();
        }
        [Test]
        public void ImportStoragePlacesList_EmptyCatalogExcel_ShouldReturnStoragePlacesListFromStoragePlacesExcel() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().HaveCount(data.StoragePlaceTestsDataList.Count);
            for (int i = 0; i < storagePlaces.Count; i++) {
                var storagePlace = storagePlaces[i];
                var storagePlaceData = data.StoragePlaceTestsDataList[i];
                storagePlace.Id.Should().NotBeEmpty();
                storagePlace.StoragePlaceName.Should().Be(storagePlaceData.StoragePlaceName);
                storagePlace.Comment.Should().Be(storagePlaceData.Description);
            }

            package.File.Delete();
        }
        [Test]
        public void ImportStoragePlacesList_EmptyStoragePlaceExcel_ShouldReturnStoragePlacesListFromCatalogExcel() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.StoragePlaceTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().HaveCount(data.CatalogTestsDataList.Count);
            for (int i = 0; i < storagePlaces.Count; i++) {
                var storagePlace = storagePlaces[i];
                var storagePlaceData = data.CatalogTestsDataList[i];
                storagePlace.Id.Should().NotBeEmpty();
                storagePlace.StoragePlaceName.Should().Be(storagePlaceData.StoragePlace);
                storagePlace.Comment.Should().BeNull();
            }

            package.File.Delete();
        }

        [Test]
        public void ImportStoragePlacesList_DuplicatesWithEmptyDescription_ShouldReturnStoragePlacesListWithoutDuplicatesWithElementWithDescription() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            var catalogDataToDouble = data.CatalogTestsDataList[0];
            var doubleData = new CatalogExcelTestData() {
                Title = catalogDataToDouble.Title,
                AuthorFirstName = catalogDataToDouble.AuthorFirstName,
                AuthorLastName = catalogDataToDouble.AuthorLastName,
                Series = catalogDataToDouble.Series,
                SeriesName = catalogDataToDouble.SeriesName,
                VolumeNumber = catalogDataToDouble.VolumeNumber,
                PublishingHouse = catalogDataToDouble.PublishingHouse,
                Town = catalogDataToDouble.Town,
                StoragePlace = data.StoragePlaceTestsDataList[0].StoragePlaceName,
                Year = catalogDataToDouble.Year,
                ISBN = catalogDataToDouble.ISBN,
                Language = catalogDataToDouble.Language,
                Comment = catalogDataToDouble.Comment
            };
            data.CatalogTestsDataList.Add(doubleData);
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().HaveCount(data.CatalogTestsDataList.Count + data.StoragePlaceTestsDataList.Count - 1);
            storagePlaces.Should().OnlyHaveUniqueItems();
            storagePlaces.Should().Contain(a => a.Comment == data.StoragePlaceTestsDataList[0].Description);

            package.File.Delete();
        }
        [Test]
        public void ImportStoragePlacesList_Null_ShouldReturnStoragePlacesListWithoutOneElement() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            var emptyStorageElement = data.CatalogTestsDataList[0];
            emptyStorageElement.StoragePlace = null;
            data.CatalogTestsDataList.Add(emptyStorageElement);
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var storagePlaces = dataImport.ImportStoragePlacesList();
            // Assert
            storagePlaces.Should().HaveCount(data.StoragePlaceTestsDataList.Count + data.CatalogTestsDataList.Count-2);
            var catalogData = data.CatalogTestsDataList;
            var storagePlaceData = data.StoragePlaceTestsDataList;
            foreach (var storagePlace in storagePlaces) {
                storagePlace.Id.Should().NotBeEmpty();
            }
            storagePlaces.Should().OnlyContain(a => 
                catalogData.Any(b => b.StoragePlace == a.StoragePlaceName)||
                storagePlaceData.Any(b => b.StoragePlaceName == a.StoragePlaceName));
            package.File.Delete();
        }
        [Test]
        public void ImportCategoriesList_ShouldReturnCategories() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var categories = dataImport.ImportCategoriesList();
            // Assert
            categories.Should().HaveSameCount(data.CategoryTestsDataList);
            for (int i = 0; i < categories.Count; i++) {
                var category = categories[i];
                var categoryData = data.CategoryTestsDataList[i];
                category.Should().BeEquivalentTo(categoryData.CategoryName);
            }

            package.File.Delete();
        }
        [Test]
        public void ImportCategoriesList_EmptyExcel_ShouldReturnEmptyCategoriesList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CategoryTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var categories = dataImport.ImportCategoriesList();
            // Assert
            categories.Should().BeEmpty();

            package.File.Delete();
        }
        [Test]
        public void ImportBooksList_ShouldReturnBooksList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var books = dataImport.ImportBooksList();
            // Assert
            books.Should().HaveSameCount(data.CatalogTestsDataList);
            for (int i = 0; i < books.Count; i++) {
                var book = books[i];
                var catalogData = data.CatalogTestsDataList[i];
                book.Id.Should().NotBeEmpty();
                book.Title.Should().Be(catalogData.Title);
                book.PublishmentYear.Should().Be(Convert.ToInt32(catalogData.Year));
                book.ISBN.Should().Be(catalogData.ISBN);
                book.Language.Should().Be(catalogData.LanguageEnum);
                book.Comment.Should().Be(catalogData.Comment);
            }

            package.File.Delete();
        }
        [Test]
        public void ImportBooksList_EmptyExcel_ShouldReturnEmptyBooksList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var books = dataImport.ImportBooksList();
            // Assert
            books.Should().BeEmpty();

            package.File.Delete();
        }

        [Test]
        public void LoadData_ShouldReturnSpreadsheetDataList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            var spreadsheetDataList = dataImport.CatalogData;
            // Act
            dataImport.LoadData();
            // Assert
            spreadsheetDataList.Should().HaveSameCount(data.CatalogTestsDataList);
            for (int i = 0; i < spreadsheetDataList.Count; i++) {
                var spreadsheetData = spreadsheetDataList[i];
                var catalogData = data.CatalogTestsDataList[i];
                var color = spreadsheetData.Category.Substring(2).Insert(0, "#");
                spreadsheetData.Title.Should().Be(catalogData.Title);
                spreadsheetData.Author.Should().Be(catalogData.Author);
                spreadsheetData.Series.Should().Be(catalogData.Series);
                spreadsheetData.PublishingHouse.Should().Be(catalogData.PublishingHouse);
                spreadsheetData.Town.Should().Be(catalogData.Town);
                spreadsheetData.Year.Should().Be(catalogData.Year);
                spreadsheetData.Language.Should().Be(catalogData.Language);
                spreadsheetData.ISBN.Should().Be(catalogData.ISBN);
                spreadsheetData.StoragePlace.Should().Be(catalogData.StoragePlace);
                spreadsheetData.Comment.Should().Be(catalogData.Comment);
                color.Should().Be(catalogData.ColorCode);
            }

            package.File.Delete();
        }
        [Test]
        public void LoadData_EmptyExcel_ShouldReturnEmptySpreadsheetDataList() {
            // Arrange
            using var package = new ExcelPackage();
            var data = new TestExcelData();
            data.CatalogTestsDataList.Clear();
            package.CreateTestsExcel(data);
            using var dataImport = new SpreadsheetDataImport(data.FileName);
            var spreadsheetDataList = dataImport.CatalogData;
            // Act
            dataImport.LoadData();
            // Assert
            spreadsheetDataList.Should().BeEmpty();
            package.File.Delete();
        }
    }
}