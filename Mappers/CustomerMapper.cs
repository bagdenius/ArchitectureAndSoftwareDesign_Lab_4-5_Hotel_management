using AutoMapper;
using Domains;
using Entities;

namespace Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();
        }
    }
}
