namespace CQRS
{
    public interface ICommand
    {
        void Execute(ISession session);
    }
}