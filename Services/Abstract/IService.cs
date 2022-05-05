using System.Linq.Expressions;

namespace Services.Abstract
{
    public interface IService<TDomain> where TDomain : class
    {
        public void Add(TDomain domain);
        public void Update(TDomain domain);
        public void Remove(int id);
        public void Remove(TDomain domain);
        public TDomain GetById(int id);
        public List<TDomain> GetAll();
        public List<TDomain> GetAll(
            Expression<Func<TDomain, bool>> filter = null,
            Func<IQueryable<TDomain>, IOrderedQueryable<TDomain>> orderBy = null,
            string includeProperties = "");
    }
}
