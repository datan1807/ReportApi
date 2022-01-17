using Api.Repositories.IRepositories;

namespace Api.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        Task CompleteAsync();
    }
}
