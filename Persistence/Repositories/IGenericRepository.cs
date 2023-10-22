using System.Linq.Expressions;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IGenericRepository<TEntity, TModel> where TEntity : class where TModel : class
    {

        IEnumerable<TModel> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TModel GetByID(object id);
        void Add(TModel model);
        void Update(TModel model);

    }
}