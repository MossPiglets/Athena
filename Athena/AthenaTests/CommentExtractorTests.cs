using System;
using System.Collections.Generic;
using System.Text;
using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests
{
    public class CommentExtractorTests
    {
        [Test]
        public void Extract_ShouldReturnTitle() {
            // Arrange 
            var text = "Visual Basic dla Windows zabawnie i pożytecznie";
            // Act
            var isbn = CommentExtractor.Extract(text);
            // Assert
            isbn.Should().Be(text);
        }
        [Test]
        public void Extract_Spaces_ShouldReturnTitle() {
            // Arrange 
            var expectedIsbn = "Visual Basic dla Windows zabawnie i pożytecznie";
            var text = $" {expectedIsbn} ";
            // Act
            var isbn = CommentExtractor.Extract(text);
            // Assert
            isbn.Should().Be(expectedIsbn);
        }
        [Test]
        public void Extract_EmptyText_ShouldReturnNull() {
            // Arrange 
            var text = string.Empty;
            // Act
            var title = CommentExtractor.Extract(text);
            // Assert
            title.Should().BeNull();
        }
        [Test]
        public void Extract_Null_ShouldReturnNull() {
            // Arrange 
            string text = null;
            // Act
            var isbn = CommentExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }
        [Test]
        public void Extract_Pause_ShouldReturnNull() {
            // Arrange 
            string text = "-";
            // Act
            var isbn = CommentExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }
        [Test]
        public void Extract_PauseAndApostrophe_ShouldReturnNull() {
            // Arrange 
            string text = "'-";
            // Act
            var isbn = CommentExtractor.Extract(text);
            // Assert
            isbn.Should().BeNull();
        }
    }
}
