namespace Core.Interfaces
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork CreateNew();
    }

}