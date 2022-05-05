using AutoMapper;
using Domains;
using Entities;
using Services.Abstract;
using System.Linq.Expressions;
using RepositoriesUoW.Abstract;

namespace Services
{
    public class HotelsService : IService<Hotel>
    {
        private readonly IRepositoriesUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelsService(IRepositoriesUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(Hotel hotel)
        {
            _unitOfWork.Hotels.Add(_mapper.Map<HotelEntity>(hotel));
        }

        public void Update(Hotel hotel)
        {
            _unitOfWork.Hotels.Update(_mapper.Map<HotelEntity>(hotel));
        }

        public void Remove(int id)
        {
            _unitOfWork.Hotels.Remove(id);
        }

        public void Remove(Hotel hotel)
        {
            _unitOfWork.Hotels.Remove(_mapper.Map<HotelEntity>(hotel));
        }

        public Hotel GetById(int id)
        {
            return _mapper.Map<Hotel>(_unitOfWork.Hotels.GetById(id));
        }

        public List<Hotel> GetAll()
        {
            return _mapper.Map<List<Hotel>>(_unitOfWork.Hotels.GetAll());
        }

        public List<Hotel> GetAll(
            Expression<Func<Hotel, bool>> filter = null,
            Func<IQueryable<Hotel>, IOrderedQueryable<Hotel>> orderBy = null,
            string includeProperties = "")
        {
            return _mapper.Map<List<Hotel>>(_unitOfWork.Hotels.GetAll(
                _mapper.Map<Expression<Func<HotelEntity, bool>>>(filter),
                _mapper.Map<Func<IQueryable<HotelEntity>, IOrderedQueryable<HotelEntity>>>(orderBy),
                includeProperties));
        }
    }
}
