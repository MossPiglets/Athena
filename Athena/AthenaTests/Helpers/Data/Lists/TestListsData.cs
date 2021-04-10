using System.Collections.Generic;
using Athena.Data;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;

namespace AthenaTests.Helpers.Data.Lists
{
    public class TestListsData {
        public List<Author> Authors = AuthorsListGenerator.Generate();
        public List<Series> SeriesList = SeriesListGenerator.Generate();
        public List<PublishingHouse> PublishingHouses = PublishingHousesListGenerator.Generate();
        public List<StoragePlace> StoragePlaces = StoragePlacesListGenerator.Generate();
        public List<Category> Categories = CategoriesListGenerator.Generate();
    }
}
