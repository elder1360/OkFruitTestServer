using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infractructure.DAL.EfEntityConfigurations
{
    internal class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        private const string TableName = "purchase";
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable(TableName);
        }
    }
}
