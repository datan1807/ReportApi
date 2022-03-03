namespace Api.Models.ExtendedModels
{
    public class ExtendedTeacherEvaluation : TeacherEvaluation
    {
        public string? TeacherName { get; set; }
        public string? ReportName { get; set; }
        public string? ProjectName { get; set; }
    }
}
