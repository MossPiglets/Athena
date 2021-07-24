using Castle.Core.Internal;

namespace Athena.Import.Extractors {
    public class StoragePlaceNameExtractor {
        public static string Extract(string text) {
            if (text.IsNullOrEmpty()) {
                return null;
            }

            return text.Trim();
        }
    }
}