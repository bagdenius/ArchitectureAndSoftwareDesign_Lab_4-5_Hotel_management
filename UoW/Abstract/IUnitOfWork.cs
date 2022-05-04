using Repositories;

namespace UoW.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        public HotelsRepository Hotels { get; }
        public RoomsRepository Rooms { get; }
        public CustomersRepository Customers { get; }
        public void Save();
    }
}
