using System;
using System.Collections.Generic;
using System.Linq;
using Athena.Data;
using Athena.Import;
using Athena.Import.Extractors;
using AthenaTests.Helpers.Data.Lists;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class ImportBookValidatorTests
    {
        [Test]
        public void CheckAuthors_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var authors = data.Authors;
            ICollection<Author> authorsOfOneBook = new List<Author>() {authors[0]};
            // Act
            Action act = () => ImportBookValidator.CheckAuthors(authors, authorsOfOneBook);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckAuthors_EmptyList_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var authors = data.Authors;
            ICollection<Author> authorsOfOneBook = new List<Author>();
            // Act
            Action act = () => ImportBookValidator.CheckAuthors(authors, authorsOfOneBook);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckAuthors_Null_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var authors = data.Authors;
            ICollection<Author> authorsOfOneBook = null;
            // Act
            Action act = () => ImportBookValidator.CheckAuthors(authors, authorsOfOneBook);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckAuthors_AuthorNotAtList_ShouldThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var authors = data.Authors;
            ICollection<Author> authorsOfOneBook = new List<Author>() {authors[0]};
            authors.RemoveAt(0);
            // Act
            Action act = () => ImportBookValidator.CheckAuthors(authors, authorsOfOneBook);
            // Assert
            var author = authorsOfOneBook.ToList()[0];
            act.Should().Throw<ExtractorException>($"Cannot find author on ImportAuthorList, author [{author}]", $"{author.FirstName} {author.LastName}");
        }
        [Test]
        public void CheckAuthors_DoubleInAuthorsList_ShouldThrowInvalidOperationException() {
            // Arrange
            var data = new TestListsData();
            var authors = data.Authors;
            ICollection<Author> authorsOfOneBook = new List<Author>() {authors[0]};
            authors.Add(authors[0]);
            // Act
            Action act = () => ImportBookValidator.CheckAuthors(authors, authorsOfOneBook);
            // Assert
            act.Should().Throw<InvalidOperationException>("Sequence contains more than one element");
        }
        [Test]
        public void CheckSeries_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var seriesList = data.SeriesList;
            Series series = seriesList[0];
            // Act
            Action act = () => ImportBookValidator.CheckSeries(seriesList, series);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckSeries_Null_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var seriesList = data.SeriesList;
            Series series = null;
            // Act
            Action act = () => ImportBookValidator.CheckSeries(seriesList, series);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckSeries_SeriesNotAtSeriesList_ShouldThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var seriesList = data.SeriesList;
            Series series = seriesList[0];
            seriesList.RemoveAt(0);
            // Act
            Action act = () => ImportBookValidator.CheckSeries(seriesList, series);
            // Assert
            act.Should().Throw<ExtractorException>($"Cannot find series on ImportSeriesList, series [{series}]");
        }
        [Test]
        public void CheckSeries_DoubleInSeriesList_ShouldThrowInvalidOperationException() {
            // Arrange
            var data = new TestListsData();
            var seriesList = data.SeriesList;
            Series series = seriesList[0];
            seriesList.Add(series);
            // Act
            Action act = () => ImportBookValidator.CheckSeries(seriesList, series);
            // Assert
            act.Should().Throw<InvalidOperationException>("Sequence contains more than one element");
        }
        [Test]
        public void CheckPublishingHouse_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var publishingHouses = data.PublishingHouses;
            PublishingHouse publishingHouse = publishingHouses[0];
            // Act
            Action act = () => ImportBookValidator.CheckPublishingHouse(publishingHouses, publishingHouse);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckPublishingHouse_Null_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var publishingHouses = data.PublishingHouses;
            PublishingHouse publishingHouse = null;
            // Act
            Action act = () => ImportBookValidator.CheckPublishingHouse(publishingHouses, publishingHouse);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckPublishingHouse_PublisherNotAtList_ShouldThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var publishingHouses = data.PublishingHouses;
            PublishingHouse publishingHouse = publishingHouses[0];
            publishingHouses.RemoveAt(0);
            // Act
            Action act = () => ImportBookValidator.CheckPublishingHouse(publishingHouses, publishingHouse);
            // Assert
            act.Should().Throw<ExtractorException>($"Cannot find publishing house on ImportPublishingHousesList, publisher [{publishingHouse}]");
        }
        [Test]
        public void CheckPublishingHouse_DoubleOnPublishingHouseList_ShouldThrowInvalidOperationException() {
            // Arrange
            var data = new TestListsData();
            var publishingHouses = data.PublishingHouses;
            PublishingHouse publishingHouse = publishingHouses[0];
            publishingHouses.Add(publishingHouse);
            // Act
            Action act = () => ImportBookValidator.CheckPublishingHouse(publishingHouses, publishingHouse);
            // Assert
            act.Should().Throw<InvalidOperationException>("Sequence contains more than one element");
        }
        [Test]
        public void CheckStoragePlace_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var storagePlaces = data.StoragePlaces;
            StoragePlace storagePlace = storagePlaces[0];
            // Act
            Action act = () => ImportBookValidator.CheckStoragePlace(storagePlaces, storagePlace);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckStoragePlace_Null_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var storagePlaces = data.StoragePlaces;
            StoragePlace storagePlace = null;
            // Act
            Action act = () => ImportBookValidator.CheckStoragePlace(storagePlaces, storagePlace);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckStoragePlace_StoragePlaceNotAtList_ShouldThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var storagePlaces = data.StoragePlaces;
            StoragePlace storagePlace = storagePlaces[0];
            storagePlaces.RemoveAt(0);
            // Act
            Action act = () => ImportBookValidator.CheckStoragePlace(storagePlaces, storagePlace);
            // Assert
            act.Should().Throw<ExtractorException>($"Cannot find storage place on ImportStoragePlacesList, storage place [{storagePlace}]");
        }
        [Test]
        public void CheckStoragePlace_StoragePlaceNotAtList_ShouldThrowInvalidOperationException() {
            // Arrange
            var data = new TestListsData();
            var storagePlaces = data.StoragePlaces;
            StoragePlace storagePlace = storagePlaces[0];
            storagePlaces.Add(storagePlace);
            // Act
            Action act = () => ImportBookValidator.CheckStoragePlace(storagePlaces, storagePlace);
            // Assert
            act.Should().Throw<InvalidOperationException>("Sequence contains more than one element");
        }
        [Test]
        public void CheckCategory_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var categories = data.Categories;
            var bookCategories = new List<Category>() {categories[0]};
            // Act
            Action act = () => ImportBookValidator.CheckCategory(categories, bookCategories);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckCategory_Null_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var categories = data.Categories;
            List<Category> bookCategories = null;
            // Act
            Action act = () => ImportBookValidator.CheckCategory(categories, bookCategories);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckCategory_EmptyList_ShouldNotThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var categories = data.Categories;
            List<Category> bookCategories = new List<Category>();
            // Act
            Action act = () => ImportBookValidator.CheckCategory(categories, bookCategories);
            // Assert
            act.Should().NotThrow();
        }
        [Test]
        public void CheckCategory_CategoryNotAtList_ShouldThrowExtractorException() {
            // Arrange
            var data = new TestListsData();
            var categories = data.Categories;
            var bookCategories = new List<Category>() {categories[0]};
            categories.RemoveAt(0);
            // Act
            Action act = () => ImportBookValidator.CheckCategory(categories, bookCategories);
            // Assert
            act.Should().Throw<ExtractorException>($"Cannot find category on ImportCategoriesList, category [{bookCategories}]");
        }
        [Test]
        public void CheckCategory_DoubleInCategoriesList_ShouldThrowInvalidOperationException() {
            // Arrange
            var data = new TestListsData();
            var categories = data.Categories;
            var bookCategories = new List<Category>() {categories[0]};
            categories.Add(categories[0]);
            // Act
            Action act = () => ImportBookValidator.CheckCategory(categories, bookCategories);
            // Assert
            act.Should().Throw<InvalidOperationException>("Sequence contains more than one element");
        }
    }
}
