using Domains;
using Services.Abstract;
using UoW.Abstract;

namespace Services
{
    public class HotelsService : IService<Hotel>
    {
        private IUnitOfWork _unitOfWork;

        public HotelsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Hotel domain)
        {
            _unitOfWork.Hotels.Add(domain);
        }

        public void Update(Hotel domain)
        {
            _unitOfWork.Hotels.Update(domain);
        }

        public void Remove(Hotel domain)
        {
            _unitOfWork.Hotels.Remove(domain);
        }

        public Hotel GetById(int id)
        {
            return _unitOfWork.Hotels.GetById(id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _unitOfWork.Hotels.GetAll();
        }
    }
}
