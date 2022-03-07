using Api.Dtos;
using Api.Global;
using Api.Models;
using Api.Parameters;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Delete(ProjectDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            var entities = await _unitOfWork.ProjectRepository.GetAll();    
            return _mapper.Map<IEnumerable<ProjectDto>>(entities);
        }

        public async Task<ProjectDto> GetById(object id)
        {
            var entity = await _unitOfWork.ProjectRepository.GetById(id);
            return _mapper.Map<ProjectDto>(entity);
        }

        public async Task Inactive(int id)
        {
            var entity = await _unitOfWork.ProjectRepository.GetById(id);
            entity.Status = "Inactive";
            await _unitOfWork.ProjectRepository.Update(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Insert(ProjectDto entity)
        {
            entity.Status = "Active";
            var dto = _mapper.Map<Project>(entity);
            await _unitOfWork.ProjectRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PagingData<ProjectDto>> Search(ProjectParameter param)
        {
            var entities = await _unitOfWork.ProjectRepository.Search(param);
            return new PagingData<ProjectDto>
            {
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageIndex = entities.PageIndex,
                PageSize = entities.PageSize,
                TotalCount = entities.TotalCount,
                TotalPages = entities.TotalPages,
                Items = entities.Select(x => new ProjectDto
                {
                    Id = x.Id,
                    ProjectName = x.ProjectName,
                    Description = x.Description,
                    Status = x.Status
                }).ToList()
            };
        }

        public async Task Update(ProjectDto entity)
        {
            var dto = _mapper.Map<Project>(entity);
            await _unitOfWork.ProjectRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
