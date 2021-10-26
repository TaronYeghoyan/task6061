using Domain.SeedWork;
using System;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Wage { get; set; }
        public byte Workdays { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}