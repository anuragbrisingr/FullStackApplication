using System;

namespace DBClassLib.GenericRepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Implementing Repository declarations as Properties should go here.

        void Complete();
    }
}
