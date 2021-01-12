using System;
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
        public void Extract_EmptyName_ShouldReturnExtractorException() {
            // Arrange 
            var text = string.Empty;
            // Act
            Action act = () => StoragePlaceNameExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>($"StoragePlaceName is null or empty, [{text}]");
        }
        [Test]
        public void Extract_Null_ShouldReturnExtractorException() {
            // Arrange 
            string text = null;
            // Act
            Action act = () => StoragePlaceNameExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>($"StoragePlaceName is null or empty, [{text}]");
        }
    }
}
