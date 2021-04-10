using System.Collections.Generic;
using System.Linq;
using Athena.Data;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;
using Athena.Import.Extractors;
using Castle.Core.Internal;

namespace Athena.Import {
    public class ImportBookValidator {
        public static void CheckAuthors(List<Author> authors, ICollection<Author> authorsOfOneBook) {
            if (authorsOfOneBook.IsNullOrEmpty()) {
                return;
            }

            foreach (var author in authorsOfOneBook) {
                var query = authors
                    .SingleOrDefault(a => a.FirstName == author.FirstName && a.LastName == author.LastName);
                if (query == null) {
                    throw new ExtractorException($"Cannot find author on ImportAuthorList, author [{author}]",
                        $"{author.FirstName} {author.LastName}");
                }
            }
        }

        public static void CheckSeries(List<Series> seriesList, Series series) {
            if (series == null) {
                return;
            }

            if (string.IsNullOrEmpty(series.SeriesName)) {
                return;
            }

            var query = seriesList
                .SingleOrDefault(a => a.SeriesName == series.SeriesName);
            if (query == null) {
                throw new ExtractorException($"Cannot find series on ImportSeriesList, series [{series}]", $"{series}");
            }
        }

        public static void CheckPublishingHouse(List<PublishingHouse> publishingHouses,
            PublishingHouse publishingHouse) {
            if (publishingHouse == null) {
                return;
            }

            var query = publishingHouses
                .SingleOrDefault(a => a.PublisherName == publishingHouse.PublisherName);
            if (query == null) {
                throw new ExtractorException(
                    $"Cannot find publishing house on ImportPublishingHousesList, publisher [{publishingHouse}]",
                    $"{publishingHouse}");
            }
        }

        public static void CheckStoragePlace(List<StoragePlace> storagePlaces, StoragePlace storagePlace) {
            if (storagePlace == null) {
                return;
            }

            var query = storagePlaces
                .SingleOrDefault(a => a.StoragePlaceName == storagePlace.StoragePlaceName);
            if (query == null) {
                throw new ExtractorException(
                    $"Cannot find storage place on ImportStoragePlacesList, storage place [{storagePlace}]",
                    $"{storagePlace}");
            }
        }

        public static void CheckCategory(List<Category> categories, ICollection<Category> bookCategories) {
            if (bookCategories.IsNullOrEmpty()) {
                return;
            }

            foreach (var category in bookCategories) {
                if (category == null) {
                    continue;
                }

                var query = categories
                    .SingleOrDefault(a => a.Name == category.Name);
                if (query == null) {
                    throw new ExtractorException(
                        $"Cannot find category on ImportCategoriesList, category [{bookCategories}]",
                        $"{bookCategories}");
                }
            }
        }
    }
}