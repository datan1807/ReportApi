namespace Api.Parameters
{
    public class MarkParameter :GenericParameter
    {
        
        public string? Email { get; set; } = string.Empty;
        public string? AccountCode { get; set; } = string.Empty ;
        public int? ProjectId { get; set; } = 0;
        public int? CategoryId { get; set; } = 0;
    }
}
