using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.OrderId);
            builder.Property(e => e.OrderId).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(e => e.OrderTotal).HasColumnType("decimal(18,2)");

            builder.Property(e => e.CreatedBy).HasMaxLength(50);
            builder.Property(e => e.ModifiedBy).HasMaxLength(50);
        }
    }
}
