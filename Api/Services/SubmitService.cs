﻿using Api.Dtos;
using Api.Dtos.ExtendedDto;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class SubmitService : ISubmitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubmitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Delete(SubmitDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubmitDto>> GetAll()
        {
            var entities = await _unitOfWork.SubmitRepository.GetAll();
            return _mapper.Map<IEnumerable<SubmitDto>>(entities);
        }

        public async Task<SubmitDto> GetById(object id)
        {
            var entity = await _unitOfWork.SubmitRepository.GetById(id);
            return _mapper.Map<SubmitDto>(entity);
        }

        public async Task<ExtendedSubmitDto> GetByProjectAndReport(int reportId, int projectId)
        {
            var entity = await _unitOfWork.SubmitRepository.GetByReportAndProject(reportId, projectId);
            if(entity != null)
            {
                return new ExtendedSubmitDto
                {
                    Id = entity.Id,
                    ProjectId = entity.ProjectId,
                    ProjectName = entity.ProjectName,
                    ReportId = entity.ReportId,
                    ReportName = entity.ReportName,
                    SubmitTime = entity.SubmitTime,
                    ReportUrl = entity.ReportUrl,
                };
            }
            else
            {
                return null;
            }
            
        }

        public async Task Insert(SubmitDto entity)
        {
            var dto = _mapper.Map<Submit>(entity);
            await _unitOfWork.SubmitRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(SubmitDto entity)
        {
            var dto = _mapper.Map<Submit>(entity);
            await _unitOfWork.SubmitRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
