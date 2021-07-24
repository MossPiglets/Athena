using System;

namespace Athena.Import.Extractors {
    [Serializable]
    public class ExtractorException : Exception {
        public string Text { get; }

        public ExtractorException(string message, string text) : base(message) {
            Text = text;
        }
    }
}