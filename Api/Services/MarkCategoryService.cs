using Api.Dtos;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class MarkCategoryService :IMarkCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MarkCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Delete(MarkCategoryDto entity)
        {
            var dto = await _unitOfWork.MarkCategoryRepository.GetById(entity.Id);
            if (dto == null)
            {
                return;
            }
            dto.Status = "Inactive";
            await _unitOfWork.MarkCategoryRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<MarkCategoryDto>> GetAll()
        {
            var entities = await _unitOfWork.MarkCategoryRepository.GetAll();
            return _mapper.Map<IEnumerable<MarkCategoryDto>>(entities).ToList();
        }

        public async Task<MarkCategoryDto> GetById(object id)
        {
            var entity = await _unitOfWork.AccountGroupRepository.GetById(id);
            return _mapper.Map<MarkCategoryDto>(entity);
        }

        public async Task Insert(MarkCategoryDto entity)
        {
            var dto = _mapper.Map<MarkCategory>(entity);
            entity.Status = "Active";
            await _unitOfWork.MarkCategoryRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(MarkCategoryDto entity)
        {
            var dto = _mapper.Map<MarkCategory>(entity);
            await _unitOfWork.MarkCategoryRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
