using System;
using System.Collections.Generic;
using System.Text;
using Athena.Import;
using AthenaTests.Helpers;
using AthenaTests.Helpers.Data;
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
            authors.Should().HaveCount(data.CatalogTestsDataList.Count-1);
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
            var seriesList = dataImport.ImportSeriesList();
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
            var seriesList = dataImport.ImportSeriesList();
            // Assert
            seriesList.Should().HaveCount(data.CatalogTestsDataList.Count-1);
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
            var seriesList = dataImport.ImportSeriesList();
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
            publishingHouses.Should().HaveCount(data.CatalogTestsDataList.Count-1);
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
        //[Test]
        //public void ImportStoragePlacesList_ShouldReturnStoragePlacesList() {
        //    // Arrange
        //    using var package = new ExcelPackage();
        //    var data = new TestExcelData();
        //    package.CreateTestsExcel(data);
        //    using var dataImport = new SpreadsheetDataImport(data.FileName);
        //    // Act
        //    var storagePlaces = dataImport.ImportStoragePlacesList();
        //    // Assert
        //    storagePlaces.Should().HaveSameCount(data.StoragePlaceTestsDataList);
        //    for (int i = 0; i < storagePlaces.Count; i++) {
        //        var storagePlace = storagePlaces[i];
        //        var storagePlaceData = data.StoragePlaceTestsDataList[i];
        //        storagePlace.Id.Should().NotBeEmpty();
        //        storagePlace.StoragePlaceName.Should().Be(storagePlaceData.StoragePlaceName);
        //    }

        //    package.File.Delete();
        //}
    }
}