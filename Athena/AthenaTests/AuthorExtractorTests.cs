using System;
using Athena.Import.Extractors;
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
        public void Extract_FirstNameWithPause_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Zygmunt-Karol";
            var lastName = "Zeydler";
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
        public void Extract_LastNameWithPause_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Zygmunt";
            var lastName = "Zeydler-Zborowski";
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
        public void Extract_AllNamesWithPause_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Zygmunt-Karol";
            var lastName = "Zeydler-Zborowski";
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
        public void Extract_NameWithVon_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Henry von";
            var lastName = "Hendler";
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
        public void Extract_TwoAuthors_ShouldReturnAuthorsListWithTwoElement() {
            // Arrange
            var firstNameFirstAuthor = "Anne";
            var lastNameFirstAuthor = "Plichota";
            var firstNameSecondAuthor = "Cendrine";
            var lastNameSecondAuthor = "Wolf";
            var fullName =
                $"{firstNameFirstAuthor} {lastNameFirstAuthor}; {firstNameSecondAuthor} {lastNameSecondAuthor}";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(2);
            var firstAuthor = authors[0];
            var secondAuthor = authors[1];
            firstAuthor.Id.Should().NotBeEmpty();
            firstAuthor.FirstName.Should().Be(firstNameFirstAuthor);
            firstAuthor.LastName.Should().Be(lastNameFirstAuthor);
            secondAuthor.Id.Should().NotBeEmpty();
            secondAuthor.FirstName.Should().Be(firstNameSecondAuthor);
            secondAuthor.LastName.Should().Be(lastNameSecondAuthor);
        }

        [Test]
        public void Extract_PauseWithApostrophe_ShouldReturnEmptyAuthorsList() {
            // Arrange
            var text = "'-";
            // Act
            var authors = AuthorExtractor.Extract(text);
            // Assert
            authors.Should().BeEmpty();
        }

        [Test]
        public void Extract_EmptyText_ShouldReturnEmptyAuthorsList() {
            // Arrange
            var text = "";
            // Act
            var authors = AuthorExtractor.Extract(text);
            // Assert
            authors.Should().BeEmpty();
        }

        [Test]
        public void Extract_OnlyOneName_ShouldReturnAuthorListWithAuthorWithoutName() {
            // Arrange
            var fullName = "Sokrates";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().BeEmpty();
            author.LastName.Should().Be(fullName);
        }
        
        [Test]
        public void Extract_OnlyOneNameWithPause_ShouldReturnAuthorListWithAuthorWithoutName() {
            // Arrange
            var fullName = "Francais-Allemand";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().BeEmpty();
            author.LastName.Should().Be(fullName);
        }
        [Test]
        public void Extract_Pause_ShouldReturnEmptyAuthorsList() {
            // Arrange
            var text = "-";
            // Act
            var authors = AuthorExtractor.Extract(text);
            // Assert
            authors.Should().BeEmpty();
        }
        [Test]
        public void Extract_Inni_ShouldReturnEmptyAuthorsList() {
            // Arrange
            var text = "inni";
            // Act
            var authors = AuthorExtractor.Extract(text);
            // Assert
            authors.Should().BeEmpty();
        }
        [Test]
        public void Extract_Null_ShouldReturnEmptyAuthorsList() {
            // Arrange
            string text = null;
            // Act
            var authors = AuthorExtractor.Extract(text);
            // Assert
            authors.Should().BeEmpty();
        }
        [Test]
        public void Extract_QuestionsMarks_ShouldReturnExtractException() {
            // Arrange
            string text = "???";
            // Act
            Action act = () => AuthorExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>("Cannot extract data from text");
        }

        [Test]
        public void Extract_OnlyOneNameWithApostrophe_ShouldReturnAuthorListWithAuthorWithoutName() {
            // Arrange
            var fullName = "O'Rely";
            // Act
            var authors = AuthorExtractor.Extract(fullName);
            // Assert
            authors.Should().HaveCount(1);
            var author = authors[0];
            author.Id.Should().NotBeEmpty();
            author.FirstName.Should().BeEmpty();
            author.LastName.Should().Be(fullName);
        }
        [Test]
        public void Extract_FirstNameWithApostrophe_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "A'manda";
            var lastName = "Orely";
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
        public void Extract_LastNameWithApostrophe_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "Amanda";
            var lastName = "O'rely";
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
        public void Extract_AllNamesWithApostrophe_ShouldReturnAuthorsListWithOneElement() {
            // Arrange
            var firstName = "A'manda";
            var lastName = "O'rely";
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