using Core.Entities;
using Core.Interfaces;
using Infractructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        private readonly OkFruitCtx _ctx;
        public RepositoryBase(OkFruitCtx ctx) => _ctx = ctx;

        public IQueryable<T> GetAll() => _ctx.Set<T>().AsNoTracking();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) => _ctx.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) => _ctx.Set<T>().Add(entity);

        public void Update(T entity) => _ctx.Set<T>().Update(entity);

        public void Delete(T entity) => _ctx.Set<T>().Remove(entity);

    }
}
