using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class IsbnExtractorTests {
        [Test]
        public void Extract_ShouldReturnIsbn() {
            // Arrange 
            var text = "978-83-7469-105-5";
            // Act
            var isbn = IsbnExtractor.Extract(text);
            // Assert
            isbn.Should().Be(text);
        }

        [Test]
        public void Extract_Spaces_ShouldReturnIsbn() {
            // Arrange 
            var expectedIsbn = "978-83-7469-105-5";
            var text = $" {expectedIsbn} ";
            // Act
            var isbn = IsbnExtractor.Extract(text);
            // Assert
            isbn.Should().Be(expectedIsbn);
        }

        [Test]
        public void Extract_EmptyText_ShouldReturnNull() {
            // Arrange 
            var text = string.Empty;
            // Act
            var isbn = IsbnExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }

        [Test]
        public void Extract_Null_ShouldReturnNull() {
            // Arrange 
            string text = null;
            // Act
            var isbn = IsbnExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }

        [Test]
        public void Extract_Pause_ShouldReturnNull() {
            // Arrange 
            string text = "-";
            // Act
            var isbn = IsbnExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }

        [Test]
        public void Extract_PauseAndApostrophe_ShouldReturnNull() {
            // Arrange 
            string text = "'-";
            // Act
            var isbn = IsbnExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }
    }
}