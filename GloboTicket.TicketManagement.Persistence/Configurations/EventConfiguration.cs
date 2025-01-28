using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.EventId);
            builder.Property(e => e.EventId).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Price).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Artist).HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.ImageUrl).HasMaxLength(500);

            builder.Property(e => e.CreatedBy).HasMaxLength(50);
            builder.Property(e => e.ModifiedBy).HasMaxLength(50);
        }
    }
}
