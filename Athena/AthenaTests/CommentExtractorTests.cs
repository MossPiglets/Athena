using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class CommentExtractorTests {
        [Test]
        public void Extract_ShouldReturnComment() {
            // Arrange 
            var text = "wypada z boku, trochę się rozkleja";
            // Act
            var comment = CommentExtractor.Extract(text);
            // Assert
            comment.Should().Be(text);
        }

        [Test]
        public void Extract_Spaces_ShouldReturnComment() {
            // Arrange 
            var expectedComment = "wypada z boku, trochę się rozkleja";
            var text = $" {expectedComment} ";
            // Act
            var comment = CommentExtractor.Extract(text);
            // Assert
            comment.Should().Be(expectedComment);
        }

        [Test]
        public void Extract_EmptyText_ShouldReturnNull() {
            // Arrange 
            var text = string.Empty;
            // Act
            var comment = CommentExtractor.Extract(text);
            // Assert
            comment.Should().BeNull();
        }

        [Test]
        public void Extract_Null_ShouldReturnNull() {
            // Arrange 
            string text = null;
            // Act
            var comment = CommentExtractor.Extract(text);
            // Assert
            comment.Should().BeNull();
        }

        [Test]
        public void Extract_Pause_ShouldReturnNull() {
            // Arrange 
            string text = "-";
            // Act
            var comment = CommentExtractor.Extract(text);
            // Assert
            comment.Should().BeNull();
        }

        [Test]
        public void Extract_PauseAndApostrophe_ShouldReturnNull() {
            // Arrange 
            string text = "'-";
            // Act
            var comment = CommentExtractor.Extract(text);
            // Assert
            comment.Should().BeNull();
        }
    }
}