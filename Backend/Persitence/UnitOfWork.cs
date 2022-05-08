using Montrac.API.Domain.Repository;

namespace Montrac.API.Persistence
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