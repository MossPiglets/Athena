using Athena.Data;
using Athena.Data.Books;
using Athena.Data.Borrowings;
using Athena.Data.Series;
using Athena.Data.PublishingHouses;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Athena.EventManagers;

namespace Athena {
    public class ApplicationDbContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<StoragePlace> StoragePlaces { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=athena.sqlite");
            // optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            
            builder.Entity<Book>().Configure();

            builder.Entity<Author>()
                .HasKey(a => a.Id);

            builder.Entity<Series>()
                .HasKey(a => a.Id);

            builder.Entity<PublishingHouse>()
                .HasKey(a => a.Id);

            builder.Entity<StoragePlace>()
                .HasKey(a => a.Id);

            builder.Entity<Borrowing>()
                .HasKey(a => a.Id);

            builder.Entity<Category>()
                .HasKey(a => a.Name);
        }
        public bool WasModified()
        {
            return this.ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                              || e.State == EntityState.Modified
                                              || e.State == EntityState.Deleted);
        }
    }

}