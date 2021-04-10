using System;
using Athena.Data;
using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class LanguageExtractorTests {

        [Test]
        public void Extract_Pl_ShouldReturnEnum() {
            // Arrange
            var text = "PL";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.PL);
        }
        [Test]
        public void Extract_Eng_ShouldReturnEnum() {
            // Arrange
            var text = "ENG";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.ENG);
        }
        [Test]
        public void Extract_Ru_ShouldReturnEnum() {
            // Arrange
            var text = "RU";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.RU);
        }
        [Test]
        public void Extract_Fr_ShouldReturnEnum() {
            // Arrange
            var text = "FR";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.FR);
        }
        [Test]
        public void Extract_De_ShouldReturnEnum() {
            // Arrange
            var text = "DE";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.DE);
        }
        [Test]
        public void Extract_Ua_ShouldReturnEnum() {
            // Arrange
            var text = "UK";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.UK);
        }

        [Test]
        public void Extract_TextWithSpaces_ShouldReturnEnum() {
            // Arrange
            var text = " UK ";
            // Act
            var language = LanguageExtractor.Extract(text);
            // Assert
            language.Should().Be(Language.UK);
        }
        [Test]
        public void Extract_Kr_ShouldReturnExtractException() {
            // Arrange
            var text = "KR";
            // Act
            Action act = () => LanguageExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>("Cannot extract language from text");
        }
        [Test]
        public void Extract_EmptyText_ShouldReturnExtractException() {
            // Arrange
            var text = string.Empty;
            // Act
            Action act = () => LanguageExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>($"Language is null or empty, [{text}]");
        }
        [Test]
        public void Extract_Null_ShouldReturnExtractException() {
            // Arrange
            string text = null;
            // Act
            Action act = () => LanguageExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>($"Language is null or empty, [{text}]");
        }
    }
}
