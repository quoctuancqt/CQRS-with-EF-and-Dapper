namespace CQRS.Repository
{
    using Domain;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> pression = null);

        TEntity FindBy(params object[] keyValues);

        Task<TEntity> FindByAsync(params object[] keyValues);

        IQueryable<TEntity> AsNoTracking(Expression<Func<TEntity, bool>> pression = null);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
