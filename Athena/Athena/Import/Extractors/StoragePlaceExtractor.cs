using System;
using Athena.Data;

namespace Athena.Import.Extractors {
    public class StoragePlaceExtractor {
        public static StoragePlace Extract(string boxName, string comment = null) {
            return new StoragePlace {
                Id = Guid.NewGuid(),
                StoragePlaceName = StoragePlaceNameExtractor.Extract(boxName),
                Comment = StoragePlaceCommentExtractor.Extract(comment)
            };
        }
    }
}