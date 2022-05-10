using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.DAL.EfEntityConfigurations
{
    internal class UnitTypeConfiguration : IEntityTypeConfiguration<UnitType>
    {
        private const string TableName = "unitType";
        public void Configure(EntityTypeBuilder<UnitType> builder)
        {
            builder.ToTable(TableName);
            builder.Property(p => p.Name).HasMaxLength(20);
        }
    }
}
