using Api.Data;
using Api.Models;
using Api.Repositories;
using Api.Repositories.IRepositories;

namespace Api.UnitOfWorks
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly QlreportContext context = new QlreportContext();

        public IAccountRepository AccountRepository { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UnitOfWork()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
           Init();
        }
        private void Init()
        {
            AccountRepository = new AccountRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
