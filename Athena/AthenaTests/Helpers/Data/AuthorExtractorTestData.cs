using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaTests.Helpers.Data
{
    public class AuthorExtractorTestData {
        public string simpleName = "Andrzej Sapkowski";
        public string nameWithPolishCharacters = "Ąęóśłżźćń Aęóśłżźćń";
        public string nameWithRussianCharacters = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя АаБбВвГг";
        public string nameWithSecondName = "Liliana Elena Wroska";
        public string nameWithOneInitial = "B. Kwiatek";
        public string nameWithTwoInitials = "D. J. Barskaya";
        public string nameWithWordAndTwoInitials = "George R. R. Martin";
        public string nameWithAllInitials = "K. J. A.";
        public string nameWithPause = "Zygmunt Zeydler-Zborowski";
        public string nameWithVon = "Henry von Hendler";
        public string twoAuthors = "Anne Plichota; Cendrine Wolf";
        public string onlyPause = "'-";
    }
}
