﻿using Api.Data;
using Api.Global;
using Api.Models;
using Api.Models.ExtendedModels;
using Api.Parameters;
using Api.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MarkRepository : GenericRepository<Mark>, IMarkRepository
    {
        private readonly QlreportContext _context;

        public MarkRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExtendedMark>> GetByGroup(int groupId, int role)
        {
            var entities = await _context.Marks.Where(m => m.Account.RoleId == role).Join(
                _context.AccountGroups,
                m => m.AccountId,
                g => g.AccountId,
                (m,g) => new ExtendedMark
                {
                    AccountCode = m.Account.AccountCode,
                    Fullname = m.Account.Fullname,
                    Email = m.Account.Email,
                    
                }).ToListAsync();
            return null;
        }

        public async Task<PagedList<ExtendedMark>> Search(MarkParameter param)
        {
            var entities = await _context.Marks.Where(m => m.Account.Email.Contains(param.Email)).Join(
                _context.AccountGroups,
                m => m.Account.Id,
                g => g.AccountId,
                (m,g) => new ExtendedMark { 
                AccountCode = m.Account.AccountCode,
                Email = m.Account.Email,
                Fullname = m.Account.Fullname,
                ProjectId = g.Group.ProjectId,
                ProjectName =g.Group.Project.Name,
                Semeter = g.Group.Semester,
                Year = g.Group.Year,
                }).OrderByDescending(o => o.Year)
                .ToListAsync();
            if (String.IsNullOrEmpty(param.AccountCode))
            {
                entities = entities.Where(m => m.AccountCode == param.AccountCode).ToList();
            }
            if(param.ProjectId > 0)
            {
                entities = entities.Where(m => m.ProjectId == param.ProjectId).ToList();
            }
            return PagedList<ExtendedMark>.ToPagedList(entities, param.PageNumber, param.PageSize);
        }
    }
}