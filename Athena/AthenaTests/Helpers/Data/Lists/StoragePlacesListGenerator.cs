using System;
using System.Collections.Generic;
using Athena.Data;
using Athena.Data.StoragePlaces;

namespace AthenaTests.Helpers.Data.Lists {
    public class StoragePlacesListGenerator {
        public static List<StoragePlace> Generate() {
            return new List<StoragePlace> {
                new StoragePlace {
                    Id = Guid.NewGuid(),
                    StoragePlaceName = "Biurko Anki",
                    Comment = null
                },
                new StoragePlace {
                    Id = Guid.NewGuid(),
                    StoragePlaceName = "V",
                    Comment = "Białe, po butach"
                }
            };
        }
    }
}