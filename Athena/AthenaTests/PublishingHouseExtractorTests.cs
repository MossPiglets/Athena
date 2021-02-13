using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class PublishingHouseExtractorTests
    {
        [Test]
        public void Extractor_ShouldReturnPublishingHouse() {
            // Arrange
            var text = "Zakład wydawniczo-propagandowy PTTK";
            // Act
            var publishingHouse = PublishingHouseExtractor.Extract(text);
            // Assert
            publishingHouse.Id.Should().NotBeEmpty();
            publishingHouse.PublisherName.Should().Be(text);
        }
        [Test]
        public void Extractor_NameWithSpace_ShouldReturnPublishingHouse() {
            // Arrange
            var name = "Zakład wydawniczo-propagandowy PTTK";
            var text = $" {name} ";
            // Act
            var publishingHouse = PublishingHouseExtractor.Extract(text);
            // Assert
            publishingHouse.Id.Should().NotBeEmpty();
            publishingHouse.PublisherName.Should().Be(name);
        }
        [Test]
        public void Extractor_ApostropheAndPause_ShouldReturnEmptyPublishingHouse() {
            // Arrange
            var text = "'-";
            // Act
            var publishingHouse = PublishingHouseExtractor.Extract(text);
            // Assert
            publishingHouse.Id.Should().BeEmpty();
            publishingHouse.PublisherName.Should().BeNull();
        }
        [Test]
        public void Extractor_Pause_ShouldReturnEmptyPublishingHouse() {
            // Arrange
            var text = "-";
            // Act
            var publishingHouse = PublishingHouseExtractor.Extract(text);
            // Assert
            publishingHouse.Id.Should().BeEmpty();
            publishingHouse.PublisherName.Should().BeNull();
        }
        [Test]
        public void Extractor_EmptyName_ShouldReturnEmptyPublishingHouse() {
            // Arrange
            var text = string.Empty;
            // Act
            var publishingHouse = PublishingHouseExtractor.Extract(text);
            // Assert
            publishingHouse.Id.Should().BeEmpty();
            publishingHouse.PublisherName.Should().BeNull();
        }
        [Test]
        public void Extractor_Null_ShouldReturnEmptyPublishingHouse() {
            // Arrange
            string text = null;
            // Act
            var publishingHouse = PublishingHouseExtractor.Extract(text);
            // Assert
            publishingHouse.Id.Should().BeEmpty();
            publishingHouse.PublisherName.Should().BeNull();
        }
    }
}
