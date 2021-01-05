using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using Athena.Data;
using OfficeOpenXml;

namespace Athena.Import {
    public class SpreadsheetDataImport: IDisposable {
        private ExcelPackage _package;
        private ExcelWorksheet _catalog;
        private ExcelWorksheet _legend;

        public SpreadsheetDataImport(string path) {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(new FileInfo(path));
            _catalog= _package.Workbook.Worksheets[0];
            _legend = _package.Workbook.Worksheets[1];
        }

        public List<Book> ImportBooksList() {
            // extractory sa do regexow, beda wypluwac konkretny obiekty, ktore bede zczytywac z listy tutaj

        }

        public void Dispose() {
            _package.Dispose();
        }
    }
}