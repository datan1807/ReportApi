﻿namespace Api.Dtos
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Submits { get; set; }
    }
}
