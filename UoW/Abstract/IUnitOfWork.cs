using Entities;
using Repositories.Abstract;

namespace UoW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<HotelEntity> HotelsRepository { get; }
        public IRepository<RoomEntity> RoomsRepository { get; }
        public IRepository<CustomerEntity> CustomersRepository { get; }
        public void Save();
    }
}
