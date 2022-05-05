using System.Linq.Expressions;

namespace Controllers.Abstract
{
    public interface IController<TModel> where TModel : class
    {
        public void Add(TModel model);
        public void Update(TModel model);
        public void Remove(int id);
        public void Remove(TModel model);
        public TModel GetById(int id);
        public List<TModel> GetAll();
        public List<TModel> GetAll(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            string includeProperties = "");
    }
}
