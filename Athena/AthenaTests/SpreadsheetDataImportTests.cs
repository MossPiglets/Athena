using System;
using System.Collections.Generic;
using System.Text;
using Athena.Import;
using AthenaTests.Helpers;
using FluentAssertions;
using NUnit.Framework;
using OfficeOpenXml;

namespace AthenaTests {
    public class SpreadsheetDataImportTests {
        private ExcelPackage package;
        private TestExcelData data;

        [OneTimeSetUp]
        public void Setup() {
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
        public void CreateBooksList_TestExcel_ShouldReturnBook() {
            // Arrange 
            //tu uzyje mojego prywatnego pola jako sciezka
            var bookData = new SpreadsheetDataImport(data.FilePath);
            // Act
            var books = data.CreateBooksList();
            books.Should().NotBeEmpty();
            var book = books[0];
            // Assert
            //book.Title.Should().Be()
        }
    }
}