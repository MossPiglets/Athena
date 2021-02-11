using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class StoragePlaceCommentExtractorTests
    {
        [Test]
        public void Extract_ShouldReturnStoragePlaceComment() {
            // Arrange 
            var text = "Biografia, autobiografia, pamiętnik - małe, szare pudło z napisem 'this side up'";
            // Act
            var boxName = StoragePlaceCommentExtractor.Extract(text);
            // Assert
            boxName.Should().Be(text);
        }
        [Test]
        public void Extract_NameWithPauses_ShouldReturnStoragePlaceComment() {
            // Arrange
            var expectedName = "Biografia, autobiografia, pamiętnik - małe, szare pudło z napisem 'this side up'";
            var text = $" {expectedName} ";
            // Act
            var boxName = StoragePlaceCommentExtractor.Extract(text);
            // Assert
            boxName.Should().Be(expectedName);
        }
        [Test]
        public void Extract_EmptyName_ShouldReturnNull() {
            // Arrange 
            var text = string.Empty;
            // Act
            var storagePlace = StoragePlaceCommentExtractor.Extract(text);
            // Assert
            storagePlace.Should().Be(null);
        }
        [Test]
        public void Extract_Null_ShouldReturnNull() {
            // Arrange 
            string text = null;
            // Act
            var storagePlace = StoragePlaceCommentExtractor.Extract(text);
            // Assert
            storagePlace.Should().Be(null);
        }
    }
}
