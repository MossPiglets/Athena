using System;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    class ApplicationDbContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<StoragePlace> StoragePlaces { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=athena.sqlite");
            optionsBuilder.UseLazyLoadingProxies();
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
                .HasKey(a => a.StoragePlaceName);

            builder.Entity<Borrowing>()
                .HasKey(a => a.Id);

            builder.Entity<Category>()
                .HasKey(a => a.Name);
        }
    }
}