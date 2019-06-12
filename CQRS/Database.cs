namespace CQRS
{
    public interface IDatabase
    {
        T Query<T>(IQuery<T> query);
    }

    public class Database : IDatabase
    {
        private ISession _session { get; set; }

        public Database(ISession session)
        {
            _session = session;
        }

        public T Query<T>(IQuery<T> query)
        {
            var result = query.Execute(_session);
            return result;
        }
    }
}