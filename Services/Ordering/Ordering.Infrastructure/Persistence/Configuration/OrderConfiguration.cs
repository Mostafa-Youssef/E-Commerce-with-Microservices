using Ordering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Entities.EntityHelpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ordering.Infrastructure.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.OwnsOne(x => x.Address);
            builder.OwnsOne(x => x.Payment);
        }
    }
}
