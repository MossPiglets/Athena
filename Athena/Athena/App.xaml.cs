using System;
using System.Collections.Generic;
using System.Windows;
using Athena.Data;
using Microsoft.EntityFrameworkCore;

namespace Athena {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();

            //context.Books.Add(new Book() {
            //    Id = Guid.NewGuid(),
            //    Title = "Kosogłos",
            //    Authors = new List<Author>() {
            //        new Author() {
            //            Id = Guid.NewGuid(),
            //            FirstName = "Suzzane",
            //            LastName = "Collins"
            //        }
            //    },
            //    Series = new Series() {
            //        Id = Guid.NewGuid(),
            //        SeriesName = "Igrzyska śmierci",
            //        VolumeNumber = 3
            //    },
            //    Categories = new List<Category>() {
            //        new Category() {
            //            Name = CategoryName.YoungAdult
            //        },
            //        new Category() {
            //            Name = CategoryName.Adventure
            //        }
            //    },
            //    PublishingHouse = new PublishingHouse() {
            //        Id = Guid.NewGuid(),
            //        PublisherName = "Media Rodzina"
            //    },
            //    PublishmentYear = new DateTime(2011, 1, 1),
            //    ISBN = "943-83-633-544-22",
            //    Language = Language.PL,
            //    StoragePlace = new StoragePlace() {
            //        Id = Guid.NewGuid(),
            //        StoragePlaceName = "Pudło P5",
            //        Comment = "Szare pudło, po lewej"
            //    },
            //    Comment = "Wytarta okładka",
            //    Borrowing = null
            //});
            //context.SaveChanges();
        }
    }
}