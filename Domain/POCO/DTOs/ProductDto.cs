using System;

namespace Domain.POCO.DTOs
{
    public class ProductDto
    {
        public Guid id { get; set; }
        public string n { get; set; }
        public decimal p { get; set; }
        public string bc { get; set; }
        public int plu { get; set; }
    }
}