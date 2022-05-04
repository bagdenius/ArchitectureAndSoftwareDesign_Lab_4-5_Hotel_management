using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;

namespace Repositories
{
    public class HotelsRepository : IRepository<HotelEntity>
    {
        private ApplicationDbContext _context;

        public HotelsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(HotelEntity entity)
        {
            _context.Hotels.Add(entity);
        }

        public void Update(HotelEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(HotelEntity entity)
        {
            _context.Hotels.Remove(entity);
        }

        public HotelEntity GetById(int id)
        {
            return _context.Hotels.Find(id);
        }

        public IEnumerable<HotelEntity> GetAll()
        {
            return _context.Hotels;
        }
    }
}
