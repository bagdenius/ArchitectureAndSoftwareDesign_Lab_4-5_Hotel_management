using System.Linq.Expressions;

namespace Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Remove(int id);
        public void Remove(TEntity entity);
        public TEntity GetById(int id);
        public List<TEntity> GetAll();
    }
}
