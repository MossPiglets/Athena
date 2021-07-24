using System.ComponentModel;
using Athena.EnumLocalizations;

namespace Athena.Data.Categories {
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum CategoryName {
        [LocalizedDescription("Album", typeof(Resources.Categories))]
        Album,

        [LocalizedDescription("Atlas", typeof(Resources.Categories))]
        Atlas,

        [LocalizedDescription("Audiobook", typeof(Resources.Categories))]
        Audiobook,

        [LocalizedDescription("Biography", typeof(Resources.Categories))]
        Biography,

        [LocalizedDescription("Economy", typeof(Resources.Categories))]
        Economy,

        [LocalizedDescription("ForChildren", typeof(Resources.Categories))]
        ForChildren,

        [LocalizedDescription("YoungAdult", typeof(Resources.Categories))]
        YoungAdult,

        [LocalizedDescription("Fantasy", typeof(Resources.Categories))]
        Fantasy,

        [LocalizedDescription("Philosophy", typeof(Resources.Categories))]
        Philosophy,

        [LocalizedDescription("History", typeof(Resources.Categories))]
        History,

        [LocalizedDescription("Informatics", typeof(Resources.Categories))]
        Informatics,

        [LocalizedDescription("Linguistics", typeof(Resources.Categories))]
        Linguistics,

        [LocalizedDescription("Classic", typeof(Resources.Categories))]
        Classic,

        [LocalizedDescription("Comic", typeof(Resources.Categories))]
        Comic,

        [LocalizedDescription("Culinary", typeof(Resources.Categories))]
        Culinary,

        [LocalizedDescription("NonFiction", typeof(Resources.Categories))]
        NonFiction,

        [LocalizedDescription("LanguageLearning", typeof(Resources.Categories))]
        LanguageLearning,

        [LocalizedDescription("Science", typeof(Resources.Categories))]
        Science,

        [LocalizedDescription("TextBook", typeof(Resources.Categories))]
        TextBook,

        [LocalizedDescription("Poetry", typeof(Resources.Categories))]
        Poetry,

        [LocalizedDescription("Guide", typeof(Resources.Categories))]
        Guide,

        [LocalizedDescription("Law", typeof(Resources.Categories))]
        Law,

        [LocalizedDescription("Adventure", typeof(Resources.Categories))]
        Adventure,

        [LocalizedDescription("Religion", typeof(Resources.Categories))]
        Religion,

        [LocalizedDescription("Romance", typeof(Resources.Categories))]
        Romance,

        [LocalizedDescription("PersonalDevelopment", typeof(Resources.Categories))]
        PersonalDevelopment,

        [LocalizedDescription("Thriller", typeof(Resources.Categories))]
        Thriller,

        [LocalizedDescription("Sociology", typeof(Resources.Categories))]
        Sociology,

        [LocalizedDescription("Recreation", typeof(Resources.Categories))]
        Recreation,

        [LocalizedDescription("Art", typeof(Resources.Categories))]
        Art,

        [LocalizedDescription("Tourism", typeof(Resources.Categories))]
        Tourism,

        [LocalizedDescription("Relationship", typeof(Resources.Categories))]
        Relationship,

        [LocalizedDescription("CrimeNovel", typeof(Resources.Categories))]
        CrimeNovel
    }
}