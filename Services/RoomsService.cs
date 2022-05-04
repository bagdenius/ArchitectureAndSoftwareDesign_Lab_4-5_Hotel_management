using Domains;
using Entities;
using Repositories.Abstract;
using Services.Abstract;
using System.Linq.Expressions;
using UoW.Abstract;

namespace Services
{
    public class RoomsService : IService<Room>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IRepository<RoomEntity> _roomsRepository;
        public void Add(Room room)
        {
            _unitOfWork.Rooms.Add(room);
        }

        public void Update(Room room)
        {
            _unitOfWork.Rooms.Update(room);
        }

        public void Remove(int id)
        {
            _unitOfWork.Rooms.Remove(id);
        }

        public void Remove(Room room)
        {
            _unitOfWork.Rooms.Remove(room);
        }

        public Room GetById(int id)
        {
            return _unitOfWork.Rooms.GetById(id);
        }

        public IEnumerable<Room> GetAll(
            Expression<Func<Room, bool>> filter = null,
            Func<IQueryable<Room>, IOrderedQueryable<Room>> orderBy = null,
            string includeProperties = "")
        {
            return _unitOfWork.Rooms.GetAll();
        }
    }
}
