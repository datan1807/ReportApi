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
    public class MarkService : IMarkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MarkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Delete(MarkDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarkDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExtendedMarkDto>> GetByGroup(int groupId, bool isClose)
        {
            var entities = await _unitOfWork.MarkRepository.GetByGroup(groupId, isClose);
            var result = entities.Select(x => new ExtendedMarkDto
            {
                Id = x.Id,
                AccountCode = x.AccountCode,
                AccountId = x.AccountId,
                Email = x.Email,
                Fullname = x.Fullname,
                Report1 = x.Report1,
                Report2 = x.Report2,
                Report3 = x.Report3,
                Report4 = x.Report4,
                Report5 = x.Report5,
                Report6 = x.Report6,
                Report7 = x.Report7,
                Final = x.Final,
                Status = x.Status,
                ProjectId = x.ProjectId,
                ProjectName = x.ProjectName,
                Semester = x.Semester,
                Year = x.Year,
                isClose = x.IsClose
            }).ToList();
            return result;
        }

        public async Task<MarkDto> GetById(object id)
        {
            var entity = await _unitOfWork.MarkRepository.GetById(id);
            return _mapper.Map<MarkDto>(entity);
        }

        public async Task Insert(MarkDto entity)
        {
            var dto = _mapper.Map<Mark>(entity);
            await _unitOfWork.MarkRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PagingData<ExtendedMarkDto>> Search(MarkParameter param)
        {
            var entities = await _unitOfWork.MarkRepository.Search(param);
            var result = new PagingData<ExtendedMarkDto>
            {
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageIndex = entities.PageIndex,
                PageSize = entities.PageSize,
                TotalCount = entities.TotalCount,
                TotalPages = entities.TotalPages,
                Items = entities.Select(x => new ExtendedMarkDto
                {
                    Id = x.Id,
                    AccountCode = x.AccountCode,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    Semester = x.Semester,
                    Year = x.Year,
                    AccountId = x.AccountId,
                    Report1 = x.Report1,
                    Report2 = x.Report2,
                    Report3 = x.Report3,
                    Report4 = x.Report4,
                    Report5 = x.Report5,
                    Report6 = x.Report6,
                    Report7 = x.Report7,
                    Final = x.Final,
                    Status = x.Status,
                    isClose = x.IsClose
                }).ToList()
            };
            return result;
        }

        public async Task Update(MarkDto entity)
        {
            var dto = _mapper.Map<Mark>(entity);
            await _unitOfWork.MarkRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
