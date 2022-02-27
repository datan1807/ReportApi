namespace Api.Dtos
{
    public class SubmitDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }      
        public int ProjectId { get; set; }
        public DateTime SubmitTime { get; set; } = DateTime.Now;
        public string? ReportUrl { get; set; }

    }
}
