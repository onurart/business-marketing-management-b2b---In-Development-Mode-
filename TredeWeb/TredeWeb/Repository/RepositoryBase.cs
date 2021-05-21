using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TradeDbContext context;
        public RepositoryBase(TradeDbContext repositoryContext)
        {
            this.context = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>()
                .Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
    }
}
