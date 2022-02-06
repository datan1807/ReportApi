using Api.Dtos;
using Api.Models;
using Api.Services.IService;
using Api.UnitOfWorks;
using AutoMapper;

namespace Api.Services
{
    public class TeacherEvaluationService : ITeacherEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherEvaluationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Delete(TeacherEvaluationDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeacherEvaluationDto>> GetAll()
        {
            var entities = await _unitOfWork.TeacherEvaluationRepository.GetAll();  
            return _mapper.Map<IEnumerable<TeacherEvaluationDto>>(entities);
        }

        public async Task<TeacherEvaluationDto> GetById(object id)
        {
            var entity = await _unitOfWork.TeacherEvaluationRepository.GetById(id);
            return _mapper.Map<TeacherEvaluationDto>(entity);
        }

        public async Task Insert(TeacherEvaluationDto entity)
        {
            var dto = _mapper.Map<TeacherEvaluation>(entity);            
            await _unitOfWork.TeacherEvaluationRepository.Insert(dto);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(TeacherEvaluationDto entity)
        {
            var dto = _mapper.Map<TeacherEvaluation>(entity);
            await _unitOfWork.TeacherEvaluationRepository.Update(dto);
            await _unitOfWork.CompleteAsync();
        }
    }
}
