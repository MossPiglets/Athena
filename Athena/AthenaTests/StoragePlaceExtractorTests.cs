using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class StoragePlaceExtractorTests
    {
        [Test]
        public void Extract_ShouldReturnStoragePlace() {
            // Arrange
            var storagePlaceName = "IX";
            var comment = "Literatura piękna, klasyka, itp.- szare pudło ACE";
            // Act
            var storagePlace = StoragePlaceExtractor.Extract(storagePlaceName, comment);
            // Assert
            storagePlace.Id.Should().NotBeEmpty();
            storagePlace.StoragePlaceName.Should().Be(storagePlaceName);
            storagePlace.Comment.Should().Be(comment);
        }
        [Test]
        public void Extract_OnlyNameArgument_ShouldReturnStoragePlace() {
            // Arrange
            var storagePlaceName = "IX";
            // Act
            var storagePlace = StoragePlaceExtractor.Extract(storagePlaceName);
            // Assert
            storagePlace.Id.Should().NotBeEmpty();
            storagePlace.StoragePlaceName.Should().Be(storagePlaceName);
            storagePlace.Comment.Should().BeNull();
        }
    }
}
