using Api.Dtos;
using Api.Models;
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

        public async Task<bool> CheckLogin(string mail, string pass)
        {
            var result = await _unitOfWork.AccountRepository.CheckLogin(mail, pass);
            return result;
        }

        public async Task Delete(AccountDto entity)
        {
            if(entity == null)
            {
                return;
            }           
            await _unitOfWork.AccountRepository.DeleteById(_mapper.Map<Account>(entity));
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var entity = await _unitOfWork.AccountRepository.GetAll();
            return _mapper.Map<IEnumerable<AccountDto>>(entity).ToList();
        }

        public async Task<AccountDto> GetById(object id)
        {
            var entity = await _unitOfWork.AccountRepository.GetById(id);
            return _mapper.Map<AccountDto>(entity);
        }

        public async Task Insert(AccountDto entity)
        {
            if(entity != null)
            {
                await _unitOfWork.AccountRepository.Insert(_mapper.Map<Account>(entity));
            }
        }

        public async Task Update(AccountDto entity)
        {
            var dto = _mapper.Map<Account>(entity);
            await _unitOfWork.AccountRepository.Update(dto);
        }
    }
}
