using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.Configurations
{
    public class EmployeeConf : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            b.Property(x => x.FirstName).IsRequired();
            b.Property(x => x.LastName).IsRequired();
            b.Property(x => x.Wage).IsRequired();
            b.Property(x => x.Workdays).IsRequired();
            b.Property(x => x.BirthDate).IsRequired(false);
            b.Property(x => x.DepartmentId).IsRequired();
        }
    }
}