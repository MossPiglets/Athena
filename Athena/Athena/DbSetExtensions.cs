using System.Collections.ObjectModel;
using System.Linq;
using Athena.Data;
using Athena.Data.PublishingHouses;
using Athena.Data.Series;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    public static class DbSetExtensions {
        public static ObservableCollection<Author> LoadAsObservableCollection(this DbSet<Author> dbSet) {
            return new ObservableCollection<Author>(dbSet
                .AsNoTracking()
                .OrderBy(a => a != null ? a.LastName : null));
        }

        public static ObservableCollection<StoragePlace> LoadAsObservableCollection(this DbSet<StoragePlace> dbSet) {
            return new ObservableCollection<StoragePlace>(dbSet
                .AsNoTracking()
                .OrderBy(a => a != null ? a.StoragePlaceName : null));
        }

        public static ObservableCollection<PublishingHouse> LoadAsObservableCollection(
            this DbSet<PublishingHouse> dbSet) {
            return new ObservableCollection<PublishingHouse>(dbSet
                .AsNoTracking()
                .OrderBy(a => a != null ? a.PublisherName : null));
        }

        public static ObservableCollection<Series> LoadAsObservableCollection(this DbSet<Series> dbSet) {
            return new ObservableCollection<Series>(dbSet
                .AsNoTracking()
                .OrderBy(a => a != null ? a.SeriesName : null));
        }

        public static ObservableCollection<Category> LoadAsObservableCollection(
            this DbSet<Category> dbSet) {
            return new ObservableCollection<Category>(dbSet.ToList());
        }
    }
}