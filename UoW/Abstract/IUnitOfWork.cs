using Entities;
using Repositories.Abstract;

namespace UoW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<HotelEntity> Hotels { get; }
        public IRepository<RoomEntity> Rooms { get; }
        public IRepository<CustomerEntity> Customers { get; }
        public void Save();
    }
}
