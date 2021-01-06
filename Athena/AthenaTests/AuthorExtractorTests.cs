using Athena.Import;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class AuthorExtractorTests {
        [Test]
        public void Extract_SimpleName_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Andrzej";
            var lastName = "Sapkowski";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithPolishCharacters_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Ąęóśłżźćń";
            var lastName = "Eąóśłżźćń";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithRussianCharacters_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";
            var lastName = "аБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithSecondName_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Liliana Elena";
            var lastName = "Wroska";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithOneInitial_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "B.";
            var lastName = "Kwiatek";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithTwoInitials_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "D. J.";
            var lastName = "Barskaya";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithWordAndTwoInitials_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "George R. R.";
            var lastName = "Martin";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }

        [Test]
        public void Extract_NameWithAllInitials_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "K. J.";
            var lastName = "A.";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }
        [Test]
        public void Extract_NameWithAllInitials_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "K. J.";
            var lastName = "A.";
            var fullName = $"{firstName} {lastName}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().Be(firstName);
            author.LastName.Should().Be(lastName);
        }
    }
}