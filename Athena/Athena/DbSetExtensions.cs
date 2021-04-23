using System.Collections.ObjectModel;
using System.Linq;
using Athena.Data;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    public static class DbSetExtensions {
        public static ObservableCollection<Author> LoadAsObservableCollection(this DbSet<Author> dbSet) {
            dbSet.Load();
            return new ObservableCollection<Author>(dbSet.Local
                .ToList()
                .OrderBy(a => a?.LastName));
        }

        public static ObservableCollection<StoragePlace> LoadAsObservableCollection(this DbSet<StoragePlace> dbSet) {
            dbSet.Load();
            return new ObservableCollection<StoragePlace>(dbSet.Local
                .ToList()
                .OrderBy(a => a.StoragePlaceName));
        }

        public static ObservableCollection<PublishingHouse> LoadAsObservableCollection(this DbSet<PublishingHouse> dbSet) {
            dbSet.Load();
            return new ObservableCollection<PublishingHouse>(dbSet.Local
                .ToList()
                .OrderBy(a => a.PublisherName));
        }

        public static ObservableCollection<Series> LoadAsObservableCollection(this DbSet<Series> dbSet) {
            dbSet.Load();
            return new ObservableCollection<Series>(dbSet.Local
                .ToList()
                .OrderBy(a => a.SeriesName));
        }

        public static ObservableCollection<Category> LoadAsObservableCollection(
            this DbSet<Category> dbSet) {
            dbSet.Load();
            return new ObservableCollection<Category>(dbSet.Local);
        }

    }
}