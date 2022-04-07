using System.Threading.Tasks;

namespace Montrac.Domain.Repository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}