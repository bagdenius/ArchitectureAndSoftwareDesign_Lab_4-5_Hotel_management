using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;

namespace Repositories
{
    public class RoomsRepository : IRepository<RoomEntity>
    {
        private ApplicationDbContext _context;

        public RoomsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(RoomEntity entity)
        {
            _context.Rooms.Add(entity);
        }

        public void Update(RoomEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(RoomEntity entity)
        {
            _context.Rooms.Remove(entity);
        }

        public RoomEntity GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public IEnumerable<RoomEntity> GetAll()
        {
            return _context.Rooms;
        }
    }
}
