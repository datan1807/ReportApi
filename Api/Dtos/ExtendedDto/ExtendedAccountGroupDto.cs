namespace Api.Dtos.ExtendedDto
{
    public class ExtendedAccountGroupDto : AccountGroupDto
    {
        public string? Email { get; set; }
        public string? ProjectName { get; set; }
        public string? Fullname { get; set; }
    }
}
