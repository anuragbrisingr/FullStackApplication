namespace DBClassLib.GenericRepositoryInterfaces
{
    public interface IUnitOfWork
    {
        // Implementing Repository declarations as Properties should go here.

        void Complete();
    }
}
