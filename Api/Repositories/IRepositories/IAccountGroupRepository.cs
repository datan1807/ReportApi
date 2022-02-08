﻿using Api.Models;
using Api.Models.ExtendedModels;

namespace Api.Repositories.IRepositories
{
    public interface IAccountGroupRepository :IGenericRepository<AccountGroup>
    {
        Task<IEnumerable<ExtendedAccountGroup>> FindByGroupId(int id);
    }
}