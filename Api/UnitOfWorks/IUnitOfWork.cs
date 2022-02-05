using Api.Repositories;

namespace Api.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        AccountRepository AccountRepository { get; }
        ReportRepository ReportRepository { get; }
        RoleRepository RoleRepository { get; }
        Task CompleteAsync();
    }
}
