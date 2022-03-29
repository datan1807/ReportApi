namespace Api.Parameters
{
    public class GroupParameter :GenericParameter
    {
        public string? Semester { get; set; } =string.Empty;
        public string? GroupCode { get; set; } =string.Empty;
        public int? Year { get; set; } = 0;
    }
}
