using Starter.Contracts;
using Starter.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Starter.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        internal readonly SQLDBContext repositoryContext;

        public RepositoryBase(SQLDBContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().AsNoTracking().Where(expression);
        }

        public void Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);
        }
    }
}
