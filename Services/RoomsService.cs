using Domains;
using Services.Abstract;
using UoW.Abstract;

namespace Services
{
    public class RoomsService : IService<Room>
    {
        private IUnitOfWork _unitOfWork;

        public RoomsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Room domain)
        {
            _unitOfWork.Rooms.Add(domain);
        }

        public void Update(Room domain)
        {
            _unitOfWork.Rooms.Update(domain);
        }

        public void Remove(Room domain)
        {
            _unitOfWork.Rooms.Remove(domain);
        }

        public Room GetById(int id)
        {
            return _unitOfWork.Rooms.GetById(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _unitOfWork.Rooms.GetAll();
        }
    }
}
