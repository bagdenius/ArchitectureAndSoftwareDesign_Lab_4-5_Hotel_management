using AutoMapper;
using Domains;
using Entities;
using Services.Abstract;
using System.Linq.Expressions;
using UoW.Abstract;

namespace Services
{
    public class CustomersService : IService<Customer>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(Customer customer)
        {
            _unitOfWork.Customers.Add(_mapper.Map<CustomerEntity>(customer));
        }

        public void Update(Customer customer)
        {
            _unitOfWork.Customers.Update(_mapper.Map<CustomerEntity>(customer));
        }

        public void Remove(int id)
        {
            _unitOfWork.Customers.Remove(id);
        }

        public void Remove(Customer customer)
        {
            _unitOfWork.Customers.Remove(_mapper.Map<CustomerEntity>(customer));
        }

        public Customer GetById(int id)
        {
            return _mapper.Map<Customer>(_unitOfWork.Customers.GetById(id));
        }

        public List<Customer> GetAll()
        {
            return _mapper.Map<List<Customer>>(_unitOfWork.Customers.GetAll());
        }
    }
}
