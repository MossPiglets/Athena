using System;
using Athena.Data;
using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class CategoryExtractTests {
        [Test]
        public void Extract_E8FCC8_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "E8FCC8";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Album
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_ABABFF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "ABABFF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Atlas
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_F2F2F2_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "F2F2F2";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Biography
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FFD5FF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FFD5FF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.ForChildren
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_E4DFEC_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "E4DFEC";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.YoungAdult
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_CD9BFF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "CD9BFF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Fantasy
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_E7CFB7_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "E7CFB7";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.History
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_AFDFFF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "AFDFFF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Informatics
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_C4BD97_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "C4BD97";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Linguistics
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FF8585_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FF8585";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Classic
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FFBDBD_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FFBDBD";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Comic
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FF61FF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FF61FF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Culinary
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_95B3D7_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "95B3D7";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.NonFiction
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FFFFCC_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FFFFCC";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.LanguageLearning
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_DA9694_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "DA9694";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Science
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_D9D9D9_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "D9D9D9";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.TextBook
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_C4D79B_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "C4D79B";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Poetry
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_808080_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "808080";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Guide
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FF3300_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FF3300";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Law
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_B7FFB7_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "B7FFB7";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Adventure
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_B9E4E5_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "B9E4E5";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Religion
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FA76A8_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FA76A8";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Romance
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FFFF99_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FFFF99";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Thriller
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_E26B0A_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "E26B0A";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Sociology
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_4BFF4B_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "4BFF4B";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Recreation
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_4FF62E_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "4FF62E";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Art
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_0099CC_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "0099CC";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Tourism
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FFDDBB_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FFDDBB";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Audiobook
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_92446D_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "92446D";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Economy
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_666633_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "666633";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Philosophy
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_9933FF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "9933FF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.PersonalDevelopment
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_3333FF_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "3333FF";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.Relationship
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_FF6600_ShouldReturnCategory() {
            // Arrange 
            var prefix = "__";
            var colorCode = "FF6600";
            var text = $"{prefix}{colorCode}";
            var expectedCategory = new Category {
                Name = CategoryName.CrimeNovel
            };
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeEquivalentTo(expectedCategory);
        }
        [Test]
        public void Extract_WrongCode_ShouldReturnExtractorException() {
            // Arrange
            var text = "_____";
            // Act
            Action act = () => CategoryExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>("Cannot extract color from text");
        }
        [Test]
        public void Extract_EmptyText_ShouldReturnExtractorException() {
            // Arrange
            var text = string.Empty;
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeNull();
        }
        [Test]
        public void Extract_Null_ShouldReturnExtractorException() {
            // Arrange
            string text = null;
            // Act
            var category = CategoryExtractor.Extract(text);
            // Assert
            category.Should().BeNull();
        }
    }
}