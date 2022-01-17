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
