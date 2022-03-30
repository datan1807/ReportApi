namespace Api.Dtos
{
    public class MarkDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double? Report1 { get; set; } = 0;
        public double? Report2 { get; set; } = 0;
        public double? Report3 { get; set; } = 0;
        public double? Report4 { get; set; } = 0;
        public double? Report5 { get; set; } = 0;
        public double? Report6 { get; set; } = 0;
        public double? Report7 { get; set; } = 0;
        public double? Final { get; set; } = 0;
        public string? Status { get; set; }
        public bool? isClose { get; set; } = false;
    }
}
