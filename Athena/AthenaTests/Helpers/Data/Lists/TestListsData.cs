using System.Collections.Generic;
using Athena.Data;

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
