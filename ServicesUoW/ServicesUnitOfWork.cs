using Domains;
using RepositoriesUoW;
using Services;
using Services.Abstract;

namespace ServicesUoW
{
    public class ServicesUnitOfWork
    {
        private readonly RepositoriesUnitOfWork _unitOfWork;

        public ServicesUnitOfWork()
        {
            _unitOfWork = new RepositoriesUnitOfWork();
        }

        private IService<Hotel> _hotelsService;
        private IService<Room> _roomsService;
        private IService<Customer> _customersService;

        public IService<Hotel> Hotels
        {
            get
            {
                if (_hotelsService == null)
                    _hotelsService = new HotelsService();
                return _hotelsService;
            }
        }

        public IRepository<RoomEntity> Rooms
        {
            get
            {
                if (_roomsRepository == null)
                    _roomsRepository = new Repository<RoomEntity>(_context);
                return _roomsRepository;
            }
        }

        public IRepository<CustomerEntity> Customers
        {
            get
            {
                if (_customersRepository == null)
                    _customersRepository = new Repository<CustomerEntity>(_context);
                return _customersRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
