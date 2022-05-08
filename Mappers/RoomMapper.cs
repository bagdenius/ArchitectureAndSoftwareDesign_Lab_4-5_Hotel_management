using AutoMapper;
using Domains;
using Entities;
using Models;
using System.Linq.Expressions;

namespace Mappers
{
    public class RoomMapper : Profile
    {
        public RoomMapper()
        {
            CreateMap<Room, RoomEntity>().ReverseMap();
            CreateMap<RoomModel, Room>().ReverseMap();
            //CreateMap<Expression<Func<Room, bool>>, Expression<Func<RoomEntity, bool>>>().ReverseMap();
            //CreateMap<Func<IQueryable<Room>, IOrderedQueryable<Room>>, Func<IQueryable<RoomEntity>, IOrderedQueryable<RoomEntity>>>().ReverseMap();
        }
    }
}
