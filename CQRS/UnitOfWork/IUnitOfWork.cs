namespace CQRS.UnitOfWork
{
    using CQRS.Repository;
    using Domain;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IRepository<Animal> AnimalRepository { get; }

        void Commit(bool isAudits = true);

        Task CommitAsync(bool isAudits = true);
    }
}
