using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Global;
using Api.Models;
using Api.Parameters;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class SubmitService : ISubmitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubmitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Delete(SubmitDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubmitDto>> GetAll()
        {
            var entities = await _unitOfWork.SubmitRepository.GetAll();
            return _mapper.Map<IEnumerable<SubmitDto>>(entities);
        }

        public async Task<SubmitDto> GetById(object id)
        {
            var entity = await _unitOfWork.SubmitRepository.GetById(id);
            return _mapper.Map<SubmitDto>(entity);
        }

        public async Task<ExtendedSubmitDto> GetByReportAndGroup(int reportId, int groupId)
        {
            var entity = await _unitOfWork.SubmitRepository.GetByReportAndGroup(reportId, groupId);
            if(entity != null)
            {
                return new ExtendedSubmitDto
                {
                    Id = entity.Id,
                    ProjectName = entity.ProjectName,
                    ReportId = entity.ReportId,
                    ReportName = entity.ReportName,
                    SubmitTime = entity.SubmitTime,
                    ReportUrl = entity.ReportUrl,
                    ProjectId = entity.ProjectId,
                    GroupId = entity.GroupId,
                };
            }
            else
            {
                return null;
            }
            
        }

        public async Task Insert(SubmitDto entity)
        {
            var dto = _mapper.Map<Submit>(entity);
            await _unitOfWork.SubmitRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PagingData<ExtendedSubmitDto>> Search(SubmitParameter param)
        {
            var entities = await _unitOfWork.SubmitRepository.Search(param);
            return new PagingData<ExtendedSubmitDto>
            {
                TotalCount = entities.Count,
                PageSize = entities.PageSize,
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageIndex = entities.PageIndex,
                TotalPages = entities.TotalPages,
                Items = entities.Select(x => new ExtendedSubmitDto { 
                    Id = x.Id,
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    ReportId = x.ReportId,
                    ReportName= x.ReportName,
                    ReportUrl= x.ReportUrl,
                    SubmitTime= x.SubmitTime,
                    GroupId = x.GroupId
                }).ToList(),
            };
        }

        public async Task Update(SubmitDto entity)
        {
            var dto = _mapper.Map<Submit>(entity);
            await _unitOfWork.SubmitRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
