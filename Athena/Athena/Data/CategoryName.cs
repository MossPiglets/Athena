using System.ComponentModel;
using Athena.Resources;

namespace Athena.Data {
    [TypeConverter (typeof(EnumDescriptionTypeConverter))]
    public enum CategoryName {
        [LocalizedDescription("Album", typeof(Categories))]
        Album,

        [LocalizedDescription("Atlas", typeof(Categories))]
        Atlas,

        [LocalizedDescription("Audiobook", typeof(Categories))]
        Audiobook,

        [LocalizedDescription("Biography", typeof(Categories))]
        Biography,

        [LocalizedDescription("Economy", typeof(Categories))]
        Economy,

        [LocalizedDescription("ForChildren", typeof(Categories))]
        ForChildren,

        [LocalizedDescription("YoungAdult", typeof(Categories))]
        YoungAdult,

        [LocalizedDescription("Fantasy", typeof(Categories))]
        Fantasy,

        [LocalizedDescription("Philosophy", typeof(Categories))]
        Philosophy,

        [LocalizedDescription("History", typeof(Categories))]
        History,

        [LocalizedDescription("Informatics", typeof(Categories))]
        Informatics,

        [LocalizedDescription("Linguistics", typeof(Categories))]
        Linguistics,

        [LocalizedDescription("Classic", typeof(Categories))]
        Classic,

        [LocalizedDescription("Comic", typeof(Categories))]
        Comic,

        [LocalizedDescription("Culinary", typeof(Categories))]
        Culinary,

        [LocalizedDescription("NonFiction", typeof(Categories))]
        NonFiction,

        [LocalizedDescription("LanguageLearning", typeof(Categories))]
        LanguageLearning,

        [LocalizedDescription("Science", typeof(Categories))]
        Science,

        [LocalizedDescription("TextBook", typeof(Categories))]
        TextBook,

        [LocalizedDescription("Poetry", typeof(Categories))]
        Poetry,

        [LocalizedDescription("Guide", typeof(Categories))]
        Guide,

        [LocalizedDescription("Law", typeof(Categories))]
        Law,

        [LocalizedDescription("Adventure", typeof(Categories))]
        Adventure,

        [LocalizedDescription("Religion", typeof(Categories))]
        Religion,

        [LocalizedDescription("Romance", typeof(Categories))]
        Romance,

        [LocalizedDescription("PersonalDevelopment", typeof(Categories))]
        PersonalDevelopment,

        [LocalizedDescription("Thriller", typeof(Categories))]
        Thriller,

        [LocalizedDescription("Sociology", typeof(Categories))]
        Sociology,

        [LocalizedDescription("Recreation", typeof(Categories))]
        Recreation,

        [LocalizedDescription("Art", typeof(Categories))]
        Art,

        [LocalizedDescription("Tourism", typeof(Categories))]
        Tourism,

        [LocalizedDescription("Relationship", typeof(Categories))]
        Relationship
    }
}