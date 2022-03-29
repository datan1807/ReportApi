namespace Api.Dtos.ExtendedDto
{
    public class ExtendedGroupInsertDto : GroupDto
    {
        public int MentorId { get; set; } = 0;
        public int LeaderId { get; set; } = 0;
        public List<int> Members { get; set; } = new List<int>();
    }
}
