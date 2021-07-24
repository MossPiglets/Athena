using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class YearExtractorTests {
        [Test]
        public void Extract_ShouldReturnYear() {
            // Arrange
            var expectedYear = 1995;
            var text = expectedYear.ToString();
            // Act
            var year = YearExtractor.Extract(text);
            // Assert
            year.Should().Be(expectedYear);
        }

        [Test]
        public void Extract_PauseAndApostrophe_ShouldReturnYear() {
            // Arrange
            var text = "'-";
            // Act
            var year = YearExtractor.Extract(text);
            // Assert
            year.Should().BeNull();
        }

        [Test]
        public void Extract_Pause_ShouldReturnYear() {
            // Arrange
            var text = "-";
            // Act
            var year = YearExtractor.Extract(text);
            // Assert
            year.Should().BeNull();
        }

        [Test]
        public void Extract_DotPause_ShouldReturnYear() {
            // Arrange
            var text = ".-";
            // Act
            var year = YearExtractor.Extract(text);
            // Assert
            year.Should().BeNull();
        }

        [Test]
        public void Extract_Empty_ShouldReturnYear() {
            // Arrange
            var text = string.Empty;
            // Act
            var year = YearExtractor.Extract(text);
            // Assert
            year.Should().BeNull();
        }

        [Test]
        public void Extract_Null_ShouldReturnYear() {
            // Arrange
            string text = null;
            // Act
            var year = YearExtractor.Extract(text);
            // Assert
            year.Should().BeNull();
        }
    }
}