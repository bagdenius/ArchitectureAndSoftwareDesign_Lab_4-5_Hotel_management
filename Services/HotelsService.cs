using AutoMapper;
using Domains;
using Entities;
using Services.Abstract;
using System.Linq.Expressions;
using UoW.Abstract;

namespace Services
{
    public class HotelsService : IService<Hotel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelsService(IUnitOfWork unitOfWork, IMapper mapper)
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
    }
}
