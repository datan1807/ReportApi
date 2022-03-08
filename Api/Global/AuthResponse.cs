using Api.Dtos.ExtendedDto;

namespace Api.Global
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public ExtendedAccountDto Account { get; set; }
    }
}
