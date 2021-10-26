using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.Configurations
{
    public class ProductConf : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).HasDefaultValue(Guid.NewGuid());
            b.Property(x => x.Name).IsRequired().HasMaxLength(15);
            b.Property(x => x.Price).IsRequired();
            b.Property(x => x.Barcode).HasMaxLength(13);
            b.HasIndex(x => x.Barcode).IsUnique();
            b.Property(x => x.PLU).IsRequired();
            b.HasIndex(x => x.PLU).IsUnique();
        }
    }
}