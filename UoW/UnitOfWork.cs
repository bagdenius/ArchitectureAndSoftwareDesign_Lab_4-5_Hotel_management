using Database;
using Repositories;
using UoW.Abstract;

namespace UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        private ApplicationDbContext _context;
        private HotelsRepository _hotelsRepository;
        private RoomsRepository _roomsRepository;
        private CustomersRepository _customersRepository;

        public HotelsRepository Hotels
        {
            get
            {
                if (_hotelsRepository == null)
                    _hotelsRepository = new HotelsRepository(_context);
                return _hotelsRepository;
            }
        }

        public RoomsRepository Rooms
        {
            get
            {
                if (_roomsRepository == null)
                    _roomsRepository = new RoomsRepository(_context);
                return _roomsRepository;
            }
        }
        
        public CustomersRepository Customers
        {
            get
            {
                if (_customersRepository == null)
                    _customersRepository = new CustomersRepository(_context);
                return _customersRepository;
            }
        }

        // *TODO: Separate the implementation of methods from the use of repositories
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
