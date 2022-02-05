namespace Api.Parameters
{
    public class AccountParameter :GenericParameter
    {
        public int ? AccountId { get; set; }
        public string? AccountName { get; set; }
        public int? RoleId { get; set; }

    }
}
