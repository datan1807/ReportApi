using Api.Data;
using Api.Repositories;

namespace Api.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QlreportContext _context;
        private bool _disposed;
        public AccountRepository AccountRepository { get; private set; }
        public ReportRepository ReportRepository { get; private set; }
        public RoleRepository RoleRepository { get; private set; }
        public GroupRepository GroupRepository { get; private set; }
        public ProjectRepository ProjectRepository { get; private set; }
        public CouncilEvaluationRepository CouncilEvaluationRepository { get; private set; }
        public SubmitRepository SubmitRepository { get; private set; }
        public TeacherEvaluationRepository TeacherEvaluationRepository { get; private set; }
        public AccountGroupRepository AccountGroupRepository { get; private set; }
        public MarkCategoryRepository MarkCategoryRepository { get; private set; }
        public MarkRepository MarkRepository { get; private set; }

        public UnitOfWork(QlreportContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            AccountRepository = new AccountRepository(_context);
            ReportRepository = new ReportRepository(_context);
            RoleRepository = new RoleRepository(_context);
            GroupRepository = new GroupRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
            CouncilEvaluationRepository = new CouncilEvaluationRepository(_context);
            SubmitRepository = new SubmitRepository(_context);
            TeacherEvaluationRepository = new TeacherEvaluationRepository(_context);
            AccountGroupRepository = new AccountGroupRepository(_context);
            MarkRepository = new MarkRepository(_context);
            MarkCategoryRepository = new MarkCategoryRepository(_context);

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
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                
            }
            _disposed = true;
        }
    }
}
