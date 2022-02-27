namespace Api.Dtos.ExtendedDto
{
    public class ExtendedSubmitDto : SubmitDto
    {
        public string? ReportName { get; set; }
        public string? ProjectName { get; set; }
        public int ProjectId { get; set; } = 0;
    }
}
