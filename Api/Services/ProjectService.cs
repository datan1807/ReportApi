using Api.Dtos;
using Api.Models;
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

        public async Task Insert(ProjectDto entity)
        {
            var dto = _mapper.Map<Project>(entity);
            await _unitOfWork.ProjectRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(ProjectDto entity)
        {
            var dto = _mapper.Map<Project>(entity);
            await _unitOfWork.ProjectRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
