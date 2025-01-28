using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GloboTicket.TicketManagement.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryId);
            builder.Property(e => e.CategoryId).HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.CreatedBy).HasMaxLength(50);
            builder.Property(e => e.ModifiedBy).HasMaxLength(50);
        }
    }
}
