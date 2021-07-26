using System;

namespace Athena.Import.Extractors {
    public class YearExtractor {
        public static int? Extract(string text) {
            if (text == "'-" || text == "-" || string.IsNullOrEmpty(text) || text == ".-") {
                return null;
            }

            return Convert.ToInt32(text.Trim());
        }
    }
}