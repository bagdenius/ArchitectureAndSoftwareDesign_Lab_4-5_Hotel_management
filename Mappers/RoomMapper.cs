using AutoMapper;
using Domains;
using Entities;
using Models;

namespace Mappers
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, RoomEntity>().ReverseMap();
            CreateMap<RoomModel, Room>().ReverseMap();
        }
    }
}
