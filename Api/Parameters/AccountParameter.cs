namespace Api.Parameters
{
    public class AccountParameter :GenericParameter
    {
        public string? Email { get; set; } = "";
        public string? Fullname { get; set; } = "";
        public int? RoleId { get; set; } = 0;
        public string? Status { get; set; } = "";

    }
}
