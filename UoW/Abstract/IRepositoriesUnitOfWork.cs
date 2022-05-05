using Entities;
using Repositories.Abstract;

namespace RepositoriesUoW.Abstract
{
    public interface IRepositoriesUnitOfWork : IDisposable
    {
        public IRepository<HotelEntity> Hotels { get; }
        public IRepository<RoomEntity> Rooms { get; }
        public IRepository<CustomerEntity> Customers { get; }
        public void Save();
    }
}
