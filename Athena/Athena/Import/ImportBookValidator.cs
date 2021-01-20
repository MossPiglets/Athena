using System.Collections.Generic;
using System.Linq;
using Athena.Data;
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
                    .Where(a => a.FirstName == author.FirstName && a.LastName == author.LastName)
                    .Select(a => a)
                    .SingleOrDefault();
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

            var query = seriesList
                .Where(a => a.SeriesName == series.SeriesName && a.VolumeNumber == series.VolumeNumber)
                .Select(a => a)
                .SingleOrDefault();
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
                .Where(a => a.PublisherName == publishingHouse.PublisherName)
                .Select(a => a)
                .SingleOrDefault();
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
                .Where(a => a.StoragePlaceName == storagePlace.StoragePlaceName && a.Comment == storagePlace.Comment)
                .Select(a => a)
                .SingleOrDefault();
            if (query == null) {
                throw new ExtractorException(
                    $"Cannot find storage place on ImportStoragePlacesList, storage place [{storagePlace}]",
                    $"{storagePlace}");
            }
        }

        public static void CheckCategory(List<Category> categories, ICollection<Category> bookCategories) {
            if (bookCategories.IsNullOrEmpty()) {
                throw new ExtractorException("Category is null or empty", "category");
            }

            foreach (var category in bookCategories) {
                var query = categories
                    .Where(a => a.Name == category.Name)
                    .Select(a => a)
                    .SingleOrDefault();
                if (query == null) {
                    throw new ExtractorException($"Cannot find category on ImportCategoriesList, category [{bookCategories}]",
                        $"{bookCategories}");
                }
            }
        }
    }
}