using AutoMapper;

namespace Athena.Data.PublishingHouses {
    public class PublishingHouseProfile : Profile {
        public PublishingHouseProfile() {
            CreateMap<PublishingHouse, PublishingHouseView>().ReverseMap();
        }
    }
}