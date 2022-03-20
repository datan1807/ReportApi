namespace Api.Parameters
{
    public class MemberParameter : GenericParameter
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        public int Year { get; set; }= 0;
        public int RoleId { get; set; } = 0;
    }
}
