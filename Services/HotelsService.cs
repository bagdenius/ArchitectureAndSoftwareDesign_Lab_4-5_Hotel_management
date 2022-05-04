using Domains;
using Services.Abstract;
using System.Linq.Expressions;
using UoW.Abstract;

namespace Services
{
    public class HotelsService : IService<Hotel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Hotel hotel)
        {
            _unitOfWork.Hotels.Add(hotel);
        }

        public void Update(Hotel hotel)
        {
            _unitOfWork.Hotels.Update(hotel);
        }

        public void Remove(int id)
        {
            _unitOfWork.Hotels.Remove(id);
        }

        public void Remove(Hotel hotel)
        {
            _unitOfWork.Hotels.Remove(hotel);
        }

        public Hotel GetById(int id)
        {
            return _unitOfWork.Hotels.GetById(id);
        }

        public IEnumerable<Hotel> GetAll(
            Expression<Func<Hotel, bool>> filter = null,
            Func<IQueryable<Hotel>, IOrderedQueryable<Hotel>> orderBy = null,
            string includeProperties = "")
        {
            return _unitOfWork.Hotels.GetAll();
        }
    }
}
