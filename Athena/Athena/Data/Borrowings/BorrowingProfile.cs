using AutoMapper;

namespace Athena.Data.Borrowings
{
    public class BorrowingProfile: Profile
    {
        public BorrowingProfile() {
            CreateMap<Borrowing, BorrowingView>().ReverseMap();
        }
    }
}
