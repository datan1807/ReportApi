using Api.Dtos;
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

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var entity = await _unitOfWork.AccountRepository.GetAll();
            return _mapper.Map<IEnumerable<AccountDto>>(entity).ToList();
        }

        public Task<AccountDto> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(AccountDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(AccountDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
