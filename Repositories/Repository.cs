using Database;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using System.Linq.Expressions;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            //_dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            var entity = _dbSet.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public List<TEntity> GetAll()
        {
            //var entities = _dbSet.ToList();
            //foreach (var entity in entities)
            //    _context.Entry(entity).State = EntityState.Detached;
            //return entities;
            return _dbSet.ToList();
        }
    }
}
