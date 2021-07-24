using Athena.Data.Categories;
using Castle.Core.Internal;

namespace Athena.Import.Extractors {
    public class CategoryExtractor {
        public static Category Extract(string color) {
            if (color.IsNullOrEmpty()) {
                return null;
            }

            color = color.Substring(2);

            CategoryName categoryName;
            switch (color) {
                case "E8FCC8":
                    categoryName = CategoryName.Album;
                    break;
                case "ABABFF":
                    categoryName = CategoryName.Atlas;
                    break;
                case "F2F2F2":
                    categoryName = CategoryName.Biography;
                    break;
                case "FFD5FF":
                    categoryName = CategoryName.ForChildren;
                    break;
                case "E4DFEC":
                    categoryName = CategoryName.YoungAdult;
                    break;
                case "CD9BFF":
                    categoryName = CategoryName.Fantasy;
                    break;
                case "E7CFB7":
                    categoryName = CategoryName.History;
                    break;
                case "AFDFFF":
                    categoryName = CategoryName.Informatics;
                    break;
                case "C4BD97":
                    categoryName = CategoryName.Linguistics;
                    break;
                case "FF8585":
                    categoryName = CategoryName.Classic;
                    break;
                case "FFBDBD":
                    categoryName = CategoryName.Comic;
                    break;
                case "FF61FF":
                    categoryName = CategoryName.Culinary;
                    break;
                case "95B3D7":
                    categoryName = CategoryName.NonFiction;
                    break;
                case "FFFFCC":
                    categoryName = CategoryName.LanguageLearning;
                    break;
                case "DA9694":
                    categoryName = CategoryName.Science;
                    break;
                case "D9D9D9":
                    categoryName = CategoryName.TextBook;
                    break;
                case "C4D79B":
                    categoryName = CategoryName.Poetry;
                    break;
                case "808080":
                    categoryName = CategoryName.Guide;
                    break;
                case "FF3300":
                    categoryName = CategoryName.Law;
                    break;
                case "B7FFB7":
                    categoryName = CategoryName.Adventure;
                    break;
                case "B9E4E5":
                    categoryName = CategoryName.Religion;
                    break;
                case "FA76A8":
                    categoryName = CategoryName.Romance;
                    break;
                case "FFFF99":
                    categoryName = CategoryName.Thriller;
                    break;
                case "E26B0A":
                    categoryName = CategoryName.Sociology;
                    break;
                case "4BFF4B":
                    categoryName = CategoryName.Recreation;
                    break;
                case "4FF62E":
                    categoryName = CategoryName.Art;
                    break;
                case "0099CC":
                    categoryName = CategoryName.Tourism;
                    break;
                case "FFDDBB":
                    categoryName = CategoryName.Audiobook;
                    break;
                case "92446D":
                    categoryName = CategoryName.Economy;
                    break;
                case "666633":
                    categoryName = CategoryName.Philosophy;
                    break;
                case "9933FF":
                    categoryName = CategoryName.PersonalDevelopment;
                    break;
                case "3333FF":
                    categoryName = CategoryName.Relationship;
                    break;
                case "FF6600":
                    categoryName = CategoryName.CrimeNovel;
                    break;
                default:
                    throw new ExtractorException("Cannot extract color from text", color);
            }

            return new Category {
                Name = categoryName
            };
        }
    }
}