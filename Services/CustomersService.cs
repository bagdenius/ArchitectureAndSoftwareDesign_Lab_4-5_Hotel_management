using Domains;
using Services.Abstract;
using UoW.Abstract;

namespace Services
{
    public class CustomersService : IService<Customer>
    {
        private IUnitOfWork _unitOfWork;

        public CustomersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Customer domain)
        {
            _unitOfWork.Customers.Add(domain);
        }

        public void Update(Customer domain)
        {
            _unitOfWork.Customers.Update(domain);
        }

        public void Remove(Customer domain)
        {
            _unitOfWork.Customers.Remove(domain);
        }

        public Customer GetById(int id)
        {
            return _unitOfWork.Customers.GetById(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }
    }
}
