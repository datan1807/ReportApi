using Api.Dtos;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class CouncilEvaluationService : ICouncilEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CouncilEvaluationService (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task Delete(CouncilEvaluationDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CouncilEvaluationDto>> GetAll()
        {
            var entities = await _unitOfWork.CouncilEvaluationRepository.GetAll();
            return _mapper.Map<IEnumerable<CouncilEvaluationDto>>(entities).ToList();
        }

        public async Task<CouncilEvaluationDto> GetById(object id)
        {
            var entity = await _unitOfWork.CouncilEvaluationRepository.GetById(id);
            return _mapper.Map<CouncilEvaluationDto>(entity);
        }

        public async Task Insert(CouncilEvaluationDto entity)
        {
            if (entity == null)
            {
                return;
            }
            else
            {
                var dto = _mapper.Map<CouncilEvaluation>(entity);
                await _unitOfWork.CouncilEvaluationRepository.Insert(dto);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task Update(CouncilEvaluationDto entity)
        {
            var dto = _mapper.Map<CouncilEvaluation>(entity);
            await _unitOfWork.CouncilEvaluationRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
