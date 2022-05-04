using System.Linq.Expressions;

namespace Services.Abstract
{
    public interface IService<TDomain> where TDomain : class
    {
        public void Add(TDomain entity);
        public void Update(TDomain entity);
        public void Remove(int id);
        public void Remove(TDomain entity);
        public TDomain GetById(int id);
        public IEnumerable<TDomain> GetAll(
            Expression<Func<TDomain, bool>> filter = null,
            Func<IQueryable<TDomain>, IOrderedQueryable<TDomain>> orderBy = null,
            string includeProperties = "");
    }
}
