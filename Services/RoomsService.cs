using AutoMapper;
using Domains;
using Entities;
using Services.Abstract;
using System.Linq.Expressions;
using UoW.Abstract;

namespace Services
{
    public class RoomsService : IService<Room>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(Room room)
        {
            _unitOfWork.Rooms.Add(_mapper.Map<RoomEntity>(room));
        }

        public void Update(Room room)
        {
            _unitOfWork.Rooms.Update(_mapper.Map<RoomEntity>(room));
        }

        public void Remove(int id)
        {
            _unitOfWork.Rooms.Remove(id);
        }

        public void Remove(Room room)
        {
            _unitOfWork.Rooms.Remove(_mapper.Map<RoomEntity>(room));
        }

        public Room GetById(int id)
        {
            return _mapper.Map<Room>(_unitOfWork.Rooms.GetById(id));
        }

        public List<Room> GetAll()
        {
            return _mapper.Map<List<Room>>(_unitOfWork.Rooms.GetAll());
        }

        public List<Room> GetAll(
            Expression<Func<Room, bool>>? filter = null,
            Func<IQueryable<Room>, IOrderedQueryable<Room>>? orderBy = null,
            string includeProperties = "")
        {
            return _mapper.Map<List<Room>>(_unitOfWork.Rooms.GetAll(
                _mapper.Map<Expression<Func<RoomEntity, bool>>>(filter),
                _mapper.Map<Func<IQueryable<RoomEntity>, IOrderedQueryable<RoomEntity>>>(orderBy),
                includeProperties));
        }
    }
}
