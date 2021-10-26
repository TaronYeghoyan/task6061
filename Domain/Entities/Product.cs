using Domain.SeedWork;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public int PLU { get; set; }
    }
}