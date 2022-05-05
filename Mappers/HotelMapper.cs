using AutoMapper;
using Domains;
using Entities;
using Models;

namespace Mappers
{
    public class HotelMapper : Profile
    {
        public HotelMapper()
        {
            CreateMap<Hotel, HotelEntity>().ReverseMap();
            CreateMap<Hotel, HotelModel>().ReverseMap();
        }
    }
}
