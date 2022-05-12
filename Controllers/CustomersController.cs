using AutoMapper;
using System.Linq.Expressions;
using Models;
using Controllers.Abstract;
using Domains;
using Services.Abstract;

namespace Controllers
{
    public class CustomersController : IController<CustomerModel>
    {
        private readonly IService<Customer> _service;
        private readonly IMapper _mapper;

        public CustomersController(IService<Customer> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(CustomerModel customer)
        {
            _service.Add(_mapper.Map<Customer>(customer));
        }

        public void Update(CustomerModel customer)
        {
            _service.Update(_mapper.Map<Customer>(customer));
        }

        public void Remove(int id)
        {
            _service.Remove(id);
        }

        public void Remove(CustomerModel customer)
        {
            _service.Remove(_mapper.Map<Customer>(customer));
        }

        public CustomerModel GetById(int id)
        {
            return _mapper.Map<CustomerModel>(_service.GetById(id));
        }

        public List<CustomerModel> GetAll()
        {
            return _mapper.Map<List<CustomerModel>>(_service.GetAll());
        }
    }
}
