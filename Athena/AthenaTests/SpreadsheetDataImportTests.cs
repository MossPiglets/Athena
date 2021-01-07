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
        private ExcelPackage package;
        private TestExcelData data;

        [OneTimeSetUp]
        public void Setup() {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            package = new ExcelPackage();
            data = new TestExcelData();
            package.CreateTestsExcel(data);
        }

        [OneTimeTearDown]
        public void CleanUp() {
            package.File.Delete();
            package.Dispose();
        }

        [Test]
        public void SpreadsheetDataImport_ShouldCreateExcelFile() {
            // Arrange
            // Act
            Action act = () => new SpreadsheetDataImport(data.FileName);
            // Assert
            act.Should().NotThrow();
        }

        [Test]
        public void ImportAuthorsList_NotDuplicates_ShouldReturnAuthorsList() {
            // Arrange
            var dataImport = new SpreadsheetDataImport(data.FileName);
            // Act
            var authors = dataImport.ImportAuthorsList();
            // Assert
            authors.Should().NotBeEmpty();
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(data.AuthorFirstName);
            author.LastName.Should().Be(data.AuthorLastName);
        }
        [Test]
        public void ImportAuthorsList_Duplicates_ShouldReturnAuthorsListWithOneAuthor() {
            // Arrange
            var dataImport = new SpreadsheetDataImport(data.FileName);
            var catalog = package.Workbook.Worksheets[data.WorksheetCatalog];
            catalog.Cells[3,2].Value = data.Author;
            // Act
            var authors = dataImport.ImportAuthorsList();
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(data.AuthorFirstName);
            author.LastName.Should().Be(data.AuthorLastName);
        }
        // todo
        //[Test]
        //public void ImportAuthorsList_TwoRowInExcel_ShouldReturnAuthorsListWithTwoAuthors() {
        //    // Arrange
        //    var dataImport = new SpreadsheetDataImport(data.FileName);
        //    var catalog = package.Workbook.Worksheets[data.WorksheetCatalog];
        //    catalog.Cells[3,2].Value = "";
        //    // Act
        //    var authors = dataImport.ImportAuthorsList();
        //    // Assert
        //    authors.Should().HaveCount(2);
        //    var author = authors[0];
        //    author.Id.Should().NotBeEmpty();
        //    author.FirstName.Should().Be(data.AuthorFirstName);
        //    author.LastName.Should().Be(data.AuthorLastName);
        //}
    }
}