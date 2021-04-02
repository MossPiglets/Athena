using System;
using Athena.Data;

namespace Athena.Import.Extractors {
    public class PublishingHouseExtractor {
        public static PublishingHouse Extract(string text) {
            if (text == "'-" || text == "-" || string.IsNullOrEmpty(text)) {
                return null;
            }

            return new PublishingHouse {
                Id = Guid.NewGuid(),
                PublisherName = text.Trim()
            };
        }
    }
}