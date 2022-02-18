namespace Api.Dtos
{
    public class AccountDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public int RoleId { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        
    }
}
