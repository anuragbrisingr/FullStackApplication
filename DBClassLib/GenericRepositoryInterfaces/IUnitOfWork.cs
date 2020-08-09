using DBClassLib.DBModels;
using System;

namespace DBClassLib.GenericRepositoryInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Implementing Repository declarations as Properties should go here.
        IGenericRepository<ProductTable> ProductRepository { get; }

        void Complete();
    }
}
