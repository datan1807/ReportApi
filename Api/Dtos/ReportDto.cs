namespace Api.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }
    }
}
