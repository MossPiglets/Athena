using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class TitleExtractorTests {
        [Test]
        public void Extract_ShouldReturnTitle() {
            // Arrange 
            var text = "Kosogłos";
            // Act
            var title = TitleExtractor.Extract(text);
            // Assert
            title.Should().Be(text);
        }

        [Test]
        public void Extract_Spaces_ShouldReturnTitle() {
            // Arrange 
            var expectedTitle = "Kosogłos";
            var text = $" {expectedTitle} ";
            // Act
            var title = TitleExtractor.Extract(text);
            // Assert
            title.Should().Be(expectedTitle);
        }

        [Test]
        public void Extract_EmptyText_ShouldReturnNull() {
            // Arrange 
            var text = string.Empty;
            // Act
            var title = TitleExtractor.Extract(text);
            // Assert
            title.Should().BeNull();
        }

        [Test]
        public void Extract_Null_ShouldReturnNull() {
            // Arrange 
            string text = null;
            // Act
            var title = TitleExtractor.Extract(text);
            // Assert
            title.Should().BeNull();
        }
    }
}