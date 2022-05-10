using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infractructure.DAL.EfEntityConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private const string TableName = "product";
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableName);
            builder.Property(p => p.Name).HasMaxLength(50);
        }
    }
}
