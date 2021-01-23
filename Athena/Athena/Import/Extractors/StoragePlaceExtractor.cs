using System;
using Athena.Data;

namespace Athena.Import.Extractors {
    public class StoragePlaceExtractor {
        public static StoragePlace Extract(string boxName, string comment = null) {
            var storagePlaceName = StoragePlaceNameExtractor.Extract(boxName);
            var storagePlaceComment = StoragePlaceCommentExtractor.Extract(comment);
            if (storagePlaceName == null && storagePlaceComment == null) {
                return null;
            }
            else {
                return new StoragePlace {
                    Id = Guid.NewGuid(),
                    StoragePlaceName = storagePlaceName,
                    Comment = storagePlaceComment
                };
            }
        }
    }
}