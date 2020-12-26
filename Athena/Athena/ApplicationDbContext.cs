using Microsoft.EntityFrameworkCore;

namespace Athena {
    class ApplicationDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=athena.sqlite");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            //builder.Entity<Book>()
            //    .HasKey(a => a.Id);
            //builder.Entity<Book>()
            //    .HasOne(a => a.Publisher)
            //    .WithMany()
            //    .HasForeignKey(a => a.Publisher;
            //FluentBuilder
        }
    }
}