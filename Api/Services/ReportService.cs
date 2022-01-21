using Api.Dtos;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public  ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Delete(ReportDto entity)
        {
            if(entity == null)
            {
                return;
            }
            await _unitOfWork.ReportRepository.DeleteById(_mapper.Map<Report>(entity));
        }

        public async Task<IEnumerable<ReportDto>> GetAll()
        {
            var entity = await _unitOfWork.ReportRepository.GetAll();
            return _mapper.Map<IEnumerable<ReportDto>>(entity).ToList();
        }

        public async Task<ReportDto> GetById(object id)
        {
            var entity = await _unitOfWork.ReportRepository.GetById(id);
            return _mapper.Map<ReportDto>(entity);
        }

        public async Task Insert(ReportDto entity)
        {
            if (entity != null)
            {
                await _unitOfWork.ReportRepository.Insert(_mapper.Map<Report>(entity));
            }
        }

        public async Task Update(ReportDto entity)
        {
            var dto = _mapper.Map<Report>(entity);
            await _unitOfWork.ReportRepository.Update(dto);
        }
    }
}
