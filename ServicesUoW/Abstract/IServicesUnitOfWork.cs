namespace ServicesUoW.Abstract
{
    public interface IServicesUnitOfWork : IDisposable
    {
        public IRepository<HotelEntity> Hotels { get; }
        public IRepository<RoomEntity> Rooms { get; }
        public IRepository<CustomerEntity> Customers { get; }
        public void Save();
    }
}
