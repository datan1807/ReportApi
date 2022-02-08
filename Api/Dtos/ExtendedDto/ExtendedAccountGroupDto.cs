namespace Api.Dtos.ExtendedDto
{
    public class ExtendedAccountGroupDto : AccountGroupDto
    {
        public AccountDto Account { get; set; } = new AccountDto();
    }
}
