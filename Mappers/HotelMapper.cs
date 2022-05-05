using AutoMapper;
using Domains;
using Entities;

namespace Mappers
{
    public class HotelMapper : Profile
    {
        public HotelMapper()
        {
            CreateMap<Hotel, HotelEntity>().ReverseMap();
        }
    }
}
