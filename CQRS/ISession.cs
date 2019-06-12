using System.Collections.Generic;

namespace CQRS
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
    }
}