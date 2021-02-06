using System;
using System.Collections.Generic;
using System.Text;

namespace Athena.Import.Extractors
{
    public class TitleExtractor
    {
        public static string Extract(string text) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }

            return text.Trim();
        }
    }
}
