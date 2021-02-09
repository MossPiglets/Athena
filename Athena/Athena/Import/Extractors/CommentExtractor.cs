namespace Athena.Import.Extractors {
    public class CommentExtractor {
        public static string Extract(string text) {
            if (text == "'-" || text == "-" || string.IsNullOrEmpty(text)) {
                return null;
            }

            return text.Trim();
        }
    }
}