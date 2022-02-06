namespace Api.Dtos
{
    public class TeacherEvaluationDto
    {
        public int Id { get; set; }
        public int SubmitId { get; set; }
        public string? TeacherId { get; set; }  
        public string? TeacherName { get; set; }
        public DateTime? CreateDate { get; set; }
        public double Point { get; set; }
        public string? Description { get; set; }

    }
}
