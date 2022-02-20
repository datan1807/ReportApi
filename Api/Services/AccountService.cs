﻿using Api.Dtos;
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
                Status = result.Status
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

        public async Task<IEnumerable<AccountDto>> GetAll()
        {
            var entity = await _unitOfWork.AccountRepository.GetAll();
            return _mapper.Map<IEnumerable<AccountDto>>(entity).ToList();
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
                    Status = entity.Status
                };
            }
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

        public async Task<ResponseData<ExtendedAccountDto>> Search(AccountParameter param)
        {
            var entities = await _unitOfWork.AccountRepository.Search(param);
            var data = new ResponseData<ExtendedAccountDto>
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
                    Status = c.Status
                }).ToList()
            };
            return data;
            
        }

        public async Task Update(AccountDto entity)
        {
            var dto = _mapper.Map<Account>(entity);
            await _unitOfWork.AccountRepository.Update(dto);
        }
    }
}
