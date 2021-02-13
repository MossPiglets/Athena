using System;
using Athena.Import.Extractors;
using FluentAssertions;
using NUnit.Framework;

namespace AthenaTests {
    public class SeriesInfoExtractorTests {
        [Test]
        public void Extractor_NameAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Igrzyska śmierci";
            var number = 3;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_OnlyName_ShouldReturnSeriesWithoutNumber() {
            // Arrange
            var text = "Igrzyska śmierci";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(text);
            series.VolumeNumber.Should().Be(0);
        }
        [Test]
        public void Extractor_OnlyVolumeNumber_ShouldReturnSeriesWithoutName() {
            // Arrange
            var text = "Tom 4";
            var number = 4;
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().BeEmpty();
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameAndTwoDigitsVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Igrzyska śmierci";
            var number = 13;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameWithPauseAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Ewa wzywa 07 - 31";
            var number = 1;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameWithApostropheAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Tytus Romek i A'Tomek";
            var number = 1;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameWithComaAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Tytus, Romek i ATomek";
            var number = 1;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameWithComaAndApostropheAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Tytus, Romek i A'Tomek";
            var number = 1;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_OnlyNameWithPause_ShouldReturnSeries() {
            // Arrange
            var text = "Bajki-rozkladanki";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(text);
            series.VolumeNumber.Should().Be(0);
        }
        [Test]
        public void Extractor_NameWithComaAndPauseAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "Druga wojna swiatowa - bohaterowie, operacje, kulisy";
            var number = 1;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameAndVolumeNumberWithSlash_ShouldReturnSeries() {
            // Arrange
            var name = "Igrzyska śmierci";
            var number = 2;
            var text = $"{name} - {number}/3";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_NameWithDotsAndVolumeNumber_ShouldReturnSeries() {
            // Arrange
            var name = "www.1939.com.pl";
            var number = 1;
            var text = $"{name} - tom {number}";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().Be(name);
            series.VolumeNumber.Should().Be(number);
        }
        [Test]
        public void Extractor_OnlyVolumeWithSmallFirstLetter_ShouldReturnSeries() {
            // Arrange
            var name = "tom 1";
            var number = 1;
            // Act 
            var series = SeriesInfoExtractor.Extract(name);
            // Assert
            series.Id.Should().NotBeEmpty();
            series.SeriesName.Should().BeEmpty();
            series.VolumeNumber.Should().Be(number);
        }
        
        [Test]
        public void Extractor_PauseAndApostrophe_ShouldReturnSeriesEmptySeries() {
            // Arrange
            var text = "'-";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Should().BeNull();
        }
        [Test]
        public void Extractor_Pause_ShouldReturnSeriesEmptySeries() {
            // Arrange
            var text = "-";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Should().BeNull();
        }
        [Test]
        public void Extractor_Empty_ShouldReturnSeriesEmptySeries() {
            // Arrange
            var text = "";
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Should().BeNull();
        }
        [Test]
        public void Extractor_Null_ShouldReturnSeriesEmptySeries() {
            // Arrange
            string text = null;
            // Act 
            var series = SeriesInfoExtractor.Extract(text);
            // Assert
            series.Should().BeNull();
        }
        [Test]
        public void Extractor_TwoMatches_ShouldReturnExtractorException() {
            // Arrange
            string text = " - tom 5 - tom 6";
            // Act 
            Action act = () => SeriesInfoExtractor.Extract(text);
            // Assert
            act.Should().Throw<ExtractorException>("Cannot extract data from text");
        }
    }
}