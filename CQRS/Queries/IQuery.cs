namespace CQRS
{
    public interface IQuery<out T>
    {
        T Execute(ISession session);
    }
}