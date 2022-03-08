namespace Api.Dtos.ExtendedDto
{
    public class ExtendedMarkDto :MarkDto
    {
        public string? Fullname { get; set; }
        public string? AccountCode { get; set; }
        public string? ProjectName { get; set; }
        public string? Email { get; set; }
        public int? ProjectId { get; set; }
        public string? Semester { get; set; }
        public int Year { get;set; }
    }
}
