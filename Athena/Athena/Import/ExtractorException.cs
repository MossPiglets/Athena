using System;
using System.Runtime.Serialization;

namespace Athena.Import {
    [Serializable]
    internal class ExtractorException : Exception {
        public string Text { get; }

        public ExtractorException(string message, string text) : base(message) {
            Text = text;
        }
    }
}