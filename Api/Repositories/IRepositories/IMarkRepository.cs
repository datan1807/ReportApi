﻿using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;

namespace Api.Repositories.IRepositories
{
    public interface IMarkRepository : IGenericRepository<Mark>
    {
        Task<PagedList<ExtendedMark>> Search(MarkParameter param);
    }
}
