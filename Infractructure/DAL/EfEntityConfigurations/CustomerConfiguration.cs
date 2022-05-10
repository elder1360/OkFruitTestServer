using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infractructure.DAL.EfEntityConfigurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        private const string TableName = "customer";
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(TableName);
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p => p.LastName).HasMaxLength(50);
        }
    }
}
