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
    }
}
