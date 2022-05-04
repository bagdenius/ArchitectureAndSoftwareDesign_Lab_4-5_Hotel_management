using Database;
using Entities;
using Repositories;
using Repositories.Abstract;
using UoW.Abstract;

namespace UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepository<HotelEntity> _hotelsRepository;
        private IRepository<RoomEntity> _roomsRepository;
        private IRepository<CustomerEntity> _customersRepository;

        public IRepository<HotelEntity> HotelsRepository
        {
            get
            {
                if (_hotelsRepository == null)
                    _hotelsRepository = new Repository<HotelEntity>(_context);
                return _hotelsRepository;
            }
        }

        public IRepository<RoomEntity> RoomsRepository
        {
            get
            {
                if (_roomsRepository == null)
                    _roomsRepository = new Repository<RoomEntity>(_context);
                return _roomsRepository;
            }
        }

        public IRepository<CustomerEntity> CustomersRepository
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
