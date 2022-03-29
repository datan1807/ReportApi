namespace Api.Parameters
{
    public class TeacherEvaluationParameter : GenericParameter
    {
        public int? reportId { get; set; }
        public string? teacherId { get; set; }
        public int? projectId { get; set; }

    }
}
