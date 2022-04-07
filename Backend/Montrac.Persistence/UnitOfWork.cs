using System.Threading.Tasks;
using Montrac.Domain.Repository;

namespace Montrac.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MontracDbContext Context;

        public UnitOfWork(MontracDbContext context)
        {
            Context = context;
        }

        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}