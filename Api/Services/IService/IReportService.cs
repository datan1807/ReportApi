using Api.Dtos;

namespace Api.Services.IService
{
    public interface IReportService : IGenericService<ReportDto>
    {
        Task DeleteReport(int id);
        Task<IEnumerable<ReportDto>> GetReport(string status);
    }
}
