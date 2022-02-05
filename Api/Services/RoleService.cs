using Api.Dtos;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class RoleService : IRoleService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        }
        public Task Delete(RoleDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            var entities =await _unitOfWork.RoleRepository.GetAll();
            return _mapper.Map<IEnumerable<RoleDto>>(entities).ToList();
        }

        public async Task<RoleDto> GetById(object id)
        {
            var entity = await _unitOfWork.RoleRepository.GetById(id);
            return _mapper.Map<RoleDto>(entity);
        }

        public async Task Insert(RoleDto entity)
        {
            if(entity == null)
            {
                return;
            }
            await _unitOfWork.RoleRepository.Insert(_mapper.Map<Role>(entity));
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(RoleDto entity)
        {
            var dto = await _unitOfWork.RoleRepository.GetById(entity);
            if(dto == null)
            {
                return ;
            }
            await _unitOfWork.RoleRepository.Update(_mapper.Map<Role>(dto));
            await _unitOfWork.CompleteAsync();
        }
    }
}
