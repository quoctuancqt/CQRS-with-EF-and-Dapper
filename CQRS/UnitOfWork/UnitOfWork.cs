namespace CQRS.UnitOfWork
{
    using CQRS.Repository;
    using Domain;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class UnitOfWork : BaseUnitOfWork<DbContext>, IUnitOfWork
    {
        public UnitOfWork(HttpContext httpContext, DbContext context) : base(httpContext, context)
        {
        }

        protected override void InitializeRepository()
        {
            AnimalRepository = new GenericRepository<Animal, DbContext>(_context);
        }

        public void Commit(bool isAudits = true)
        {
            BeforeCommit();

            _context.SaveChanges();
        }

        public async Task CommitAsync(bool isAudits = true)
        {
            BeforeCommit(isAudits);

            await _context.SaveChangesAsync();
        }

        private void BeforeCommit(bool isAudits = true)
        {
            if (isAudits)
            {
                var EntriesAdded = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).Select(e => e.Entity as IAudit);

                foreach (var e in EntriesAdded)
                {
                    if (e != null)
                    {
                        e.CreatedBy = UserName;
                        e.CreatedDate = DateTime.Now;
                    }
                }

                var EntriesModified = _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).Select(e => e.Entity as IAudit);

                foreach (var e in EntriesModified)
                {
                    if (e != null)
                    {
                        e.ModifiedBy = UserName;
                        e.ModifiedDate = DateTime.Now;
                    }
                }
            }

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IRepository<Animal> AnimalRepository { get; private set; }
    }
}
