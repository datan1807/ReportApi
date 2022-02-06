using Api.Dtos;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public Task Delete(GroupDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            var entities = await _unitOfWork.GroupRepository.GetAll();
            return _mapper.Map<IEnumerable<GroupDto>>(entities);
        }

        public async Task<GroupDto> GetById(object id)
        {
            var entity = await _unitOfWork.GroupRepository.GetById(id);
            return _mapper.Map<GroupDto>(entity);
        }

        public async Task Insert(GroupDto entity)
        {
            var dto = _mapper.Map<Group>(entity);
            await _unitOfWork.GroupRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(GroupDto entity)
        {
            var dto = _mapper.Map<Group>(entity);
            await _unitOfWork.GroupRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
