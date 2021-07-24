using System;
using Athena.Data.StoragePlaces;

namespace Athena.Import.Extractors {
    public class StoragePlaceExtractor {
        public static StoragePlace Extract(string name, string comment = null) {
            var storagePlaceName = StoragePlaceNameExtractor.Extract(name);
            var storagePlaceComment = StoragePlaceCommentExtractor.Extract(comment);
            if (storagePlaceName == null && storagePlaceComment == null) {
                return null;
            }

            return new StoragePlace {
                Id = Guid.NewGuid(),
                StoragePlaceName = storagePlaceName,
                Comment = storagePlaceComment
            };
        }
    }
}