namespace Api.Dtos
{
    public class SubmitDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string? ReportName { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateTime SubmitTime { get; set; }
        public string? SubmitUrl { get; set; }

    }
}
