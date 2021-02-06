using System;
using System.Collections.Generic;
using Athena.Data;

namespace AthenaTests.Helpers.Data.Lists {
    public class PublishingHousesListGenerator {
        public static List<PublishingHouse> Generate() {
            return new List<PublishingHouse> {
                new PublishingHouse {
                    Id = Guid.NewGuid(),
                    PublisherName = "Media Rodzina"
                },
                new PublishingHouse {
                    Id = Guid.NewGuid(),
                    PublisherName = "Jaguar"
                }
            };
        }
    }
}