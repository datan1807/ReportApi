namespace Api.Models.ExtendedModels
{
    public class ExtendedAccount : Account
    {
        public string? RoleName { get; set; }
        public string? RoleInGroup { get; set;}
    }
}
