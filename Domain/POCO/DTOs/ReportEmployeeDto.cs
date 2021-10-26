using System;

namespace Domain.POCO.DTOs
{
    public class ReportEmployeeDto
    {
        public DateTime ds { get; set; }
        public DateTime de { get; set; }
        public int ws { get; set; }
        public int we { get; set; }
        public string dn { get; set; }
    }
}