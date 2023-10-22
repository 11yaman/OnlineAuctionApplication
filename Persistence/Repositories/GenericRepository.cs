using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using AutoMapper;

namespace OnlineAuctionApplication.Persistence.Repositories
{
    public class GenericRepository<TEntity, TModel> 
        : IGenericRepository<TEntity, TModel> where TEntity : class where TModel : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> dbSet;
        protected readonly IMapper mapper;

        public GenericRepository(DbContext context, IMapper mapper)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            this.mapper = mapper;  
        }

        public virtual IEnumerable<TModel> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            var models = new List<TModel>();
            if (orderBy != null)
            {
                foreach (var item in orderBy(query).ToList())
                {
                    models.Add(mapper.Map<TModel>(item));
                }
                return models;
            }
            else
            {
                foreach (var item in query.ToList())
                {
                    models.Add(mapper.Map<TModel>(item));
                }
                return models;
            }
        }

        public virtual TModel GetByID(object id)
        {
            var entity = dbSet.Find(id);
            return mapper.Map<TModel>(entity);
        }

        public virtual void Add(TModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            dbSet.Add(entity);
        }

        public virtual void Update(TModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            dbSet.Update(entity);
        }
    }
}
