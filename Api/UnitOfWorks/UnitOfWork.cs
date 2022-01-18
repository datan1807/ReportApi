using Api.Data;
using Api.Repositories;

namespace Api.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QlreportContext _context;
        private bool _disposed;
        public AccountRepository AccountRepository { get; private set; }

        public UnitOfWork(QlreportContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            AccountRepository = new AccountRepository(_context);
        }

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(_disposed);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {

            }
            _disposed = true;
        }
    }
}
