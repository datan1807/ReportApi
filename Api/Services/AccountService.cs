using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(UnitOfWork unitOfWork, IMapper mapper) { _unitOfWork = unitOfWork; 
            _mapper = mapper;
        }
        public async Task<Account> CheckLogin(string mail, string password)
        {
            var entity = await _unitOfWork.AccountRepository.CheckLogin(mail, password);
            return _mapper.Map<Account>(entity);
        }

        public Task Delete(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Account account)
        {
            throw new NotImplementedException();
        }

        public Task Update(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
