using Domain.SeedWork;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Manager { get; set; }
    }
}