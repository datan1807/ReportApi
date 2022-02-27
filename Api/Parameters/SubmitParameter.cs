namespace Api.Parameters
{
    public class SubmitParameter : GenericParameter
    {
        public int ProjectId { get; set; } = 0;
        public int ReportId { get; set; } = 0;
        public int Year { get; set; } = DateTime.Now.Year;
        public string Semester { get; set; } = "";
    }
}
