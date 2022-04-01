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
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CheckCodeExist(string groupCode)
        {
            bool result = false;
            result = await _unitOfWork.GroupRepository.CheckExist(groupCode);
            return result;
        }

        public Task Delete(GroupDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            var entities = await _unitOfWork.GroupRepository.GetAll();
            return _mapper.Map<IEnumerable<GroupDto>>(entities);
        }

        public async Task<ExtendedGroupDto> GetByGroupId(int groupId)
        {
            var entity = await _unitOfWork.GroupRepository.GetByGroupId(groupId);
            return _mapper.Map<ExtendedGroupDto>(entity);
        }

        public async Task<GroupDto> GetById(object id)
        {
            var entity = await _unitOfWork.GroupRepository.GetById(id);
            return _mapper.Map<GroupDto>(entity);
        }

        public async Task<IEnumerable<ExtendedGroupDto>> GetGroupByAccount(string accountId)
        {
            var entities = await _unitOfWork.AccountGroupRepository.FindByAccount(accountId);
            return entities.Select(x => new ExtendedGroupDto
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                ProjectName = x.Project.ProjectName,
                Semester = x.Semester,
                Year = x.Year
            });
        }

        public async Task Insert(GroupDto entity)
        {
            var dto = _mapper.Map<Group>(entity);
            await _unitOfWork.GroupRepository.Insert(dto);
            var project = await _unitOfWork.ProjectRepository.GetById(entity.ProjectId);
            project.Status = Constants.STATUS.INACTIVE;
            await _unitOfWork.ProjectRepository.Update(project);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> InsertGroup(ExtendedGroupInsertDto dto)
        {
            try
            {
                GroupDto group = new GroupDto
                {
                    GroupCode = dto.GroupCode,
                    ProjectId = dto.ProjectId,
                    Semester = dto.Semester,
                    Year = dto.Year
                };
                var mentorId = dto.MentorId;
                var leaderId = dto.LeaderId;
                var members = dto.Members;
                var groupEntity = _mapper.Map<Group>(group);
                await _unitOfWork.GroupRepository.Insert(groupEntity);
                
                var groupId = groupEntity.Id;
                await InsertMember(mentorId, "Mentor", groupId);

                await InsertMember(leaderId,"Leader", groupId);
                foreach (var member in members)
                {
                    await InsertMember(member, "Member", groupId);
                }
                await InsertSubmit(groupId, 0);
                await InsertSubmit(groupId, 1);
                await InsertSubmit(groupId, 2);
                await InsertSubmit(groupId, 3);
                await InsertSubmit(groupId, 5);
                await InsertSubmit(groupId, 6);
                await InsertSubmit(groupId, 7);
                var project = await _unitOfWork.ProjectRepository.GetById(groupEntity.ProjectId);
                project.Status = Constants.STATUS.INACTIVE;
                await _unitOfWork.ProjectRepository.Update(project);
                await _unitOfWork.CompleteAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
            
        }
        private async Task InsertMember(int memberId, String role, int groupId)
        {
            AccountGroupDto dto = new AccountGroupDto
            {
                AccountId = memberId,
                GroupId = groupId,
                Role = role,
            };
            var entity = _mapper.Map<AccountGroup>(dto);
            await _unitOfWork.AccountGroupRepository.Insert(entity);
            if (!role.Equals("Mentor"))
            {
                await InsertMark(memberId);
            }
        }
        public async Task InsertMark(int memberId)
        {
            MarkDto mark = new MarkDto { AccountId = memberId, isClose = false };
            var entity = _mapper.Map<Mark>(mark);
            await _unitOfWork.MarkRepository.Insert(entity);
        }

        public async Task<PagingData<ExtendedGroupDto>> Search(GroupParameter param)
        {
            var entities = await _unitOfWork.GroupRepository.Search(param);
            return new PagingData<ExtendedGroupDto>
            {
                PageSize = entities.PageSize,
                HasNext = entities.HasNext,
                HasPrevious = entities.HasPrevious,
                PageIndex = entities.PageIndex,
                TotalCount = entities.TotalCount,
                TotalPages = entities.TotalPages,
                Items = entities.Select(x => new ExtendedGroupDto
                {
                    Id = x.Id,
                    GroupCode = x.GroupCode,
                    ProjectId = x.ProjectId,
                    ProjectName = x.ProjectName,
                    Semester = x.Semester,
                    Year = x.Year
                }).ToList()
            };
        }

        public async Task Update(GroupDto entity)
        {
            var dto = _mapper.Map<Group>(entity);
            await _unitOfWork.GroupRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }

        private async Task InsertSubmit(int groupId, int reportId)
        {
            SubmitDto dto = new SubmitDto
            {
                GroupId = groupId,
                ReportId = reportId
            };
            var entity = _mapper.Map<Submit>(dto);
            await _unitOfWork.SubmitRepository.Insert(entity);
        }
    }
}
