namespace Api.Dtos
{
    public class CouncilEvaluationDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public double? Point { get; set; }
        public string? Description { get; set; }
    }
}
