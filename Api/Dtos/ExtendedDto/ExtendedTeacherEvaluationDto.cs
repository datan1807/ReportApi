namespace Api.Dtos.ExtendedDto
{
    public class ExtendedTeacherEvaluationDto : TeacherEvaluationDto
    {
        public string? TeacherName { get; set; }
        public string? ReportName { get; set; }
        public string? ProjectName { get; set; }
    }
}
