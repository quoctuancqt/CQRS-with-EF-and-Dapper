namespace CQRS.Repository
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public sealed class GenericRepository<TEntity, TContext> : Repository<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        public GenericRepository(TContext context) : base(context) { }

    }
}
