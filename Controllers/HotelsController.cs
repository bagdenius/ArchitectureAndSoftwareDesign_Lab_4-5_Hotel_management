using AutoMapper;
using Controllers.Abstract;
using Domains;
using Models;
using Services.Abstract;
using System.Linq.Expressions;

namespace Controllers
{
    public class HotelsController : IController<HotelModel>
    {
        private readonly IService<Hotel> _service;
        private readonly IMapper _mapper;

        public HotelsController(IService<Hotel> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(HotelModel hotel)
        {
            _service.Add(_mapper.Map<Hotel>(hotel));
        }

        public void Update(HotelModel hotel)
        {
            _service.Update(_mapper.Map<Hotel>(hotel));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public void Remove(HotelModel hotel)
        {
            _service.Remove(_mapper.Map<Hotel>(hotel));
        }

        public HotelModel GetById(int id)
        {
            return _mapper.Map<HotelModel>(_service.GetById(id));
        }

        public List<HotelModel> GetAll()
        {
            return _mapper.Map<List<HotelModel>>(_service.GetAll());
        }

        public List<HotelModel> GetAll(
            Expression<Func<HotelModel, bool>> filter = null,
            Func<IQueryable<HotelModel>, IOrderedQueryable<HotelModel>> orderBy = null,
            string includeProperties = "")
        {
            return _mapper.Map<List<HotelModel>>(_service.GetAll(
                _mapper.Map<Expression<Func<Hotel, bool>>>(filter),
                _mapper.Map<Func<IQueryable<Hotel>, IOrderedQueryable<Hotel>>>(orderBy),
                includeProperties));
        }
    }
}
