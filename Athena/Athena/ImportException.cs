using System;

namespace Athena {
    [Serializable]
    public class ImportException : Exception {
        public ImportException(string message) : base(message) { }
    }
}