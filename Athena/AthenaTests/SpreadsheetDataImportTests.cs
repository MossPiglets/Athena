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
            Action act = () => new SpreadsheetDataImport(data.FilePath);
            // Assert
            act.Should().NotThrow();
        }

        //[Test]
        //public void ImportAuthorsList_NotDuplicates_ShouldReturnAuthorsList() {
        //    // Arrange
        //    var dataImport = new SpreadsheetDataImport(data.FilePath);
        //    // Act
        //    dataImport.ImportAuthorsList();
        //    // 
        //}
    }
}