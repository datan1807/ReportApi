namespace Api.Dtos.ExtendedDto
{
    public class ExtendedAccountDto :AccountDto
    {
        public string? RoleName { get; set; }
        public string? RoleInGroup { get; set; }
    }
}
