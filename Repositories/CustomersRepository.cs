using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;

namespace Repositories
{
    public class CustomersRepository : IRepository<CustomerEntity>
    {
        private ApplicationDbContext _context;

        public CustomersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CustomerEntity entity)
        {
            _context.Customers.Add(entity);
        }

        public void Update(CustomerEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(CustomerEntity entity)
        {
            _context.Customers.Remove(entity);
        }

        public CustomerEntity GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _context.Customers;
        }
    }
}
