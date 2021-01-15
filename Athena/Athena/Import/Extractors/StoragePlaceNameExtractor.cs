using Castle.Core.Internal;

namespace Athena.Import.Extractors
{
    public class StoragePlaceNameExtractor
    {
        public static string Extract(string text) {
            if (text.IsNullOrEmpty()) {
                throw new ExtractorException($"StoragePlaceName is null or empty, [{text}]", text);
            }

            return text.Trim();
        }
    }
}
