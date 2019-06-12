namespace CQRS.Queries.Animals
{
    using Domain;
    using System.Collections.Generic;
    using System.Linq;

    public class GetAllAnimals : IQuery<IList<Animal>>
    {
        public IList<Animal> Execute(ISession session)
        {
            return session.Query<Animal>("SELECT * FROM Animals").ToList();
        }
    }
}
