﻿using Domains;
using Domains.Abstract;
using Services.Abstract;
using System.Linq.Expressions;
using UoW.Abstract;

namespace Services
{
    public class CustomersService : IService<Customer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Customer customer)
        {
            _unitOfWork.CustomersRepository.Add(customer);
        }

        public void Update(Customer customer)
        {
            _unitOfWork.CustomersRepository.Update(customer);
        }

        public void Remove(int id)
        {
            _unitOfWork.CustomersRepository.Remove(id);
        }

        public void Remove(Customer customer)
        {
            _unitOfWork.CustomersRepository.Remove(customer);
        }

        public Customer GetById(int id)
        {
            return _unitOfWork.CustomersRepository.GetById(id);
        }

        public IEnumerable<Customer> GetAll(
            Expression<Func<Customer, bool>> filter = null,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null,
            string includeProperties = "")
        {
            return _unitOfWork.CustomersRepository.GetAll();
        }
    }
}
