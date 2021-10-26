using System;

namespace Domain.POCO.DTOs
{
    public class EmployeeDto
    {
        public Guid id { get; set; }
        public string fn { get; set; }
        public string ln { get; set; }
        public DateTime? d { get; set; }
        public int w { get; set; }
        public byte wd { get; set; }
        public string dn { get; set; }
    }
}