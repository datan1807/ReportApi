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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool?> CheckCode(string code)
        {
            return await _unitOfWork.AccountRepository.CheckCode(code);           
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await _unitOfWork.AccountRepository.CheckMail(email);
        }

        public async Task<AccountDto> CheckLogin(string mail, string pass)
        {
            var result = await _unitOfWork.AccountRepository.CheckLogin(mail, pass);
            if(result == null)
            {
                return null;
            }
            return new AccountDto
            {
                Email = result.Email,
                Fullname = result.Fullname,
                RoleId = result.RoleId,
                Birthday = result.Birthday,
                Phone = result.Phone,
                Address = result.Address,
                Status = result.Status,
                Id = result.Id,
            };
        }

        public async Task Delete(AccountDto entity)
        {
            if(entity == null)
            {
                return;
            }           
            await _unitOfWork.AccountRepository.DeleteById(_mapper.Map<Account>(entity));
        }

        public async Task<IEnumerable<ExtendedAccountDto>> GetAccountByGroup(string groupCode)
        {
            var entities = await _unitOfWork.AccountGroupRepository.GetAccountByGroup(groupCode);
            return _mapper.Map<IEnumerable<ExtendedAccountDto>>(entities).ToList();
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var entity = await _unitOfWork.AccountRepository.GetAll();
            return _mapper.Map<IEnumerable<AccountDto>>(entity).ToList();
        }

        public async Task<IEnumerable<AccountDto>> GetByCode(string code, int role)
        {
            var entities = await _unitOfWork.AccountRepository.Get(a => a.AccountCode.Contains(code) && a.RoleId == role);
            return _mapper.Map<IEnumerable<AccountDto>>(entities);
        }

        public async Task<ExtendedAccountDto> GetByEmail(string email)
        {
            var entity = await _unitOfWork.AccountRepository.GetByEmail(email);
            if(entity == null)
            {
                return null;
            }
            else
            {
                return new ExtendedAccountDto
                {
                    Email = entity.Email,
                    Address = entity.Address,
                    Birthday = entity.Birthday,
                    Fullname = entity.Fullname,
                    Phone = entity.Phone,
                    RoleId = entity.RoleId,
                    RoleName = entity.RoleName,
                    Status = entity.Status,
                    Id = entity.Id,
                    AccountCode = entity.AccountCode
                };
            }
        }

        public async Task<AccountDto> GetById(object id)
        {
            var entity = await _unitOfWork.AccountRepository.GetById(id);
            return _mapper.Map<AccountDto>(entity);
        }

        public async Task<IEnumerable<AccountDto>> GetByRole(int role)
        {
            var entities = await _unitOfWork.AccountRepository.Get(a => a.RoleId == role && a.Status == Constants.STATUS.ACTIVE);
            return _mapper.Map<IEnumerable<AccountDto>>(entities).ToList();
        }

        public async Task<PagingData<AccountDto>> GetMember(MemberParameter param)
        {
            var result = await _unitOfWork.AccountRepository.SearchAvailableMember(param);
            return new PagingData<AccountDto>
            {
                HasNext = result.HasNext,
                HasPrevious = result.HasPrevious,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages,
                Items = result.Select(x => new AccountDto
                {
                    Id = x.Id,
                    AccountCode = x.AccountCode,
                    Fullname = x.Fullname,
                    Email = x.Email,
                    RoleId = x.RoleId,
                    Status = x.Status,
                    Phone = x.Phone,
                    Address = x.Address,
                    Birthday = x.Birthday
                }).ToList()
            };
        }

        public async Task<PagingData<AccountDto>> GetMentor(MemberParameter param)
        {
            var entities = await _unitOfWork.AccountRepository.SearchMentor(param);
            return new PagingData<AccountDto>
            {
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageIndex = entities.PageIndex,
                PageSize = entities.PageSize,
                TotalCount = entities.TotalCount,
                TotalPages = entities.TotalPages,
                Items = entities.Select(x => new AccountDto
                {
                    AccountCode = x.AccountCode,
                    Id = x.Id,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    RoleId = x.RoleId
                }).ToList()
            };
        }

        public async Task Insert(AccountDto entity)
        {
            if(entity != null)
            {
                await _unitOfWork.AccountRepository.Insert(_mapper.Map<Account>(entity));
            }
        }

        public async Task<PagingData<ExtendedAccountDto>> Search(AccountParameter param)
        {
            var entities = await _unitOfWork.AccountRepository.Search(param);
            var data = new PagingData<ExtendedAccountDto>
            {
                TotalCount = entities.Count,
                PageSize = entities.PageSize,
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageIndex = entities.PageIndex,
                TotalPages = entities.TotalPages,
                Items = entities.Select(c => new ExtendedAccountDto
                {
                    Email= c.Email,
                    Fullname= c.Fullname,
                    Address = c.Address,
                    Birthday= c.Birthday,   
                    Phone= c.Phone, 
                    RoleId = c.RoleId,
                    RoleName = c.RoleName,
                    Status = c.Status,
                    Id = c.Id
                }).ToList()
            };
            return data;
            
        }

        public async Task Update(AccountDto entity)
        {
            var dto = _mapper.Map<Account>(entity);
            await _unitOfWork.AccountRepository.Update(dto);
        }

        public async Task<bool> UpdateStatus(int id)
        {
            var dto =await _unitOfWork.AccountRepository.GetById(id);
            if (dto == null)
            {
                return false;
            }
            else
            dto.Status = "Inactive";
            await _unitOfWork.AccountRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
