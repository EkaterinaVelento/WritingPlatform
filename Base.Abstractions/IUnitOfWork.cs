using System;


namespace Base.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}