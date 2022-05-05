using AutoMapper;
using Domains;
using Entities;
using Services.Abstract;
using System.Linq.Expressions;
using RepositoriesUoW.Abstract;

namespace Services
{
    public class CustomersService : IService<Customer>
    {
        private readonly IRepositoriesUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersService(IRepositoriesUnitOfWork unitOfWork, IMapper mapper)
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

        public List<Customer> GetAll(
            Expression<Func<Customer, bool>> filter = null,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null,
            string includeProperties = "")
        {
            return _mapper.Map<List<Customer>>(_unitOfWork.Customers.GetAll(
                _mapper.Map<Expression<Func<CustomerEntity, bool>>>(filter),
                _mapper.Map<Func<IQueryable<CustomerEntity>, IOrderedQueryable<CustomerEntity>>>(orderBy),
                includeProperties));
        }
    }
}
