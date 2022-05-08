namespace Montrac.API.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}