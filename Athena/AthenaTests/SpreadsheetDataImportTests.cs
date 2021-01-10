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
        public void ImportAuthorsList_Duplicates_ShouldReturnAuthorsListWithOneAuthor() {
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
        
    }
}