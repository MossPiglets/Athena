using AutoMapper;

namespace Athena.Data.Books {
    public class BookProfile : Profile {
        public BookProfile() {
            CreateMap<Book, BookView>().ReverseMap();
            CreateMap<Book, BookInListView>().ReverseMap();
        }
    }
}