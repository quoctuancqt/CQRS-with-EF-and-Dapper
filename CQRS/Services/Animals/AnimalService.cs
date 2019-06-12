namespace CQRS.Services
{
    using CQRS.UnitOfWork;
    using Domain;
    using global::Dto;

    public interface IAnimalService : IBaseService<Animal, AnimalDto>
    {
    }

    public class AnimalService : BaseService<Animal, AnimalDto>, IAnimalService
    {
        public AnimalService(IUnitOfWork unitOfWork, IDatabase database) : base(unitOfWork, database)
        {
        }
    }
}
