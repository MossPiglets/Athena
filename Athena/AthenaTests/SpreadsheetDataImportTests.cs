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

        [OneTimeSetUp]
        public void Setup() {
            package = new ExcelPackage();
            var data = new TestExcelData();
            package.CreateTestsExcel(data);

            // zrob excela za pomoca epp plus, sciezke do tego excela zapisz tutaj w prywatnym polu i potem w clean up usun tego excela
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
            using var data = new SpreadsheetDataImport("");
            // Act
            var books = data.CreateBooksList();
            books.Should().NotBeEmpty();
            var book = books[0];
            // Assert
            //book.Title.Should().Be()


        }
    }
}