using Api.Data;
using Api.Models;
using Api.Repositories.IRepositories;

namespace Api.Repositories
{
    public class TeacherEvaluationRepository : GenericRepository<TeacherEvaluation>, ITeacherEvaluationRepository
    {
        private readonly QlreportContext _context;
        public TeacherEvaluationRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
