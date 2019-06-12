namespace CQRS.UnitOfWork
{
    using System;

    public interface IBaseUnitOfWork : IDisposable
    {
        string UserId { get; }

        string UserName { get; }

        string Email { get; }
    }
}
