using Api.Data;

namespace Api.Repositories
{
    public class CouncilEvaluationRepository : GenericRepository<Models.CouncilEvaluation>
    {
        private readonly QlreportContext _context;
        public CouncilEvaluationRepository(QlreportContext context) : base(context)
        {
            _context = context;
        }
    }
}
