using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class StoragePlaceNameExtractorTests
    {
        [Test]
        public void Extract_ShouldReturnStoragePlaceName() {
            // Arrange 
            var text = "V";
            // Act
            var boxName = StoragePlaceNameExtractor.Extract(text);
            // Assert
            boxName.Should().Be(text);
        }
        [Test]
        public void Extract_NameWithPauses_ShouldReturnStoragePlaceName() {
            // Arrange
            var expectedName = "VI";
            var text = $" {expectedName} ";
            // Act
            var boxName = StoragePlaceNameExtractor.Extract(text);
            // Assert
            boxName.Should().Be(expectedName);
        }
        [Test]
        public void Extract_EmptyName_ShouldReturnNull() {
            // Arrange 
            var text = string.Empty;
            // Act
            var boxName = StoragePlaceNameExtractor.Extract(text);
            // Assert
            boxName.Should().BeNull();
        }
        [Test]
        public void Extract_Null_ShouldReturnNull() {
            // Arrange 
            string text = null;
            // Act
            var boxName = StoragePlaceNameExtractor.Extract(text);
            // Assert
            boxName.Should().BeNull();
        }
    }
}
