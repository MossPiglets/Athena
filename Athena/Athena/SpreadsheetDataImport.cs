using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Athena.Data;
using Excel = Microsoft.Office.Interop.Excel; 


namespace Athena {
    class SpreadsheetDataImport {
        public ICollection<Book> Books => _books;
        ICollection<Book> _books = new List<Book>();

        public ICollection<Book> CreateBooksList()  {
            Excel.Application xlApp = new Excel.Application(); 
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(@"catalog.xlsx") ;
            Excel._Worksheet xlWorkSheet = (Excel._Worksheet)xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;

            int rowNumber = 1589;
            int columnNumber = 10;

            for (int i = 2; i < rowNumber + 1; i++) {
                var book = new Book();
                for (int j = 1; j < columnNumber + 1; j++) {
                    book.Title = xlRange.Cells[i, 1].ToString();

                }
            }

        }

        private ICollection<Author> CreateAuthorsList(string v)
        {
            throw new NotImplementedException();
        }
    }
}