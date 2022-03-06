namespace Api.Models.ExtendedModels
{
    public class ExtendedMark :Mark
    {
        public string? Fullname { get; set; }
        public string? AccountCode { get; set; }
        public string? ProjectName { get; set; }
        public string? Email { get; set; }
        public int? ProjectId { get; set; }
        public string? Semeter { get; set; }
        public int Year { get; set; }
    }
}
