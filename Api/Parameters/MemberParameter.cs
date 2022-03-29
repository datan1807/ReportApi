using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Parameters
{
    public class MemberParameter : GenericParameter
    {
        
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Semester { get; set; }
        public int? Year { get; set; }= 0;
        public int? RoleId { get; set; } = 0;
    }
}
