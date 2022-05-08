using AutoMapper;
using Controllers.Abstract;
using Domains;
using Models;
using Services.Abstract;
using System.Linq.Expressions;

namespace Controllers
{
    public class RoomsController : IController<RoomModel>
    {
        private readonly IService<Room> _service;
        private readonly IMapper _mapper;

        public RoomsController(IService<Room> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(RoomModel room)
        {
            _service.Add(_mapper.Map<Room>(room));
        }

        public void Update(RoomModel room)
        {
            _service.Update(_mapper.Map<Room>(room));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public void Remove(RoomModel room)
        {
            _service.Remove(_mapper.Map<Room>(room));
        }

        public RoomModel GetById(int id)
        {
            return _mapper.Map<RoomModel>(_service.GetById(id));
        }

        public List<RoomModel> GetAll()
        {
            return _mapper.Map<List<RoomModel>>(_service.GetAll());
        }

        public List<RoomModel> GetAll(
            Expression<Func<RoomModel, bool>>? filter = null,
            Func<IQueryable<RoomModel>, IOrderedQueryable<RoomModel>>? orderBy = null,
            string includeProperties = "")
        {
            return _mapper.Map<List<RoomModel>>(_service.GetAll(
                _mapper.Map<Expression<Func<Room, bool>>>(filter),
                _mapper.Map<Func<IQueryable<Room>, IOrderedQueryable<Room>>>(orderBy),
                includeProperties));
        }
    }
}
