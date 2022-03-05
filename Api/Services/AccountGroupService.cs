using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class AccountGroupService : IAccountGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Delete(AccountGroupDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExtendedAccountGroupDto>> FindByGroupId(int id)
        {
            var entities = await _unitOfWork.AccountGroupRepository.FindByGroupId(id);
            return entities.Select(c => new ExtendedAccountGroupDto
            {
                GroupId = c.GroupId,
                Id = c.Id,
                AccountId = c.AccountId,
                Email = c.Email,
                Fullname = c.Fullname,
                ProjectName =c.ProjectName
            }).ToList();
        }

        public async Task<IEnumerable<AccountGroupDto>> GetAll()
        {
            var entities = await _unitOfWork.AccountGroupRepository.GetAll();
            return _mapper.Map<IEnumerable<AccountGroupDto>>(entities);
         }

        public async Task<AccountGroupDto> GetById(object id)
        {
            var entity = await _unitOfWork.AccountGroupRepository.GetById(id);
            return _mapper.Map<AccountGroupDto>(entity);
        }

        public async Task Insert(AccountGroupDto entity)
        {
            var dto = _mapper.Map<AccountGroup>(entity);
            await _unitOfWork.AccountGroupRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(AccountGroupDto entity)
        {
            var dto = _mapper.Map<AccountGroup>(entity);
            await _unitOfWork.AccountGroupRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
