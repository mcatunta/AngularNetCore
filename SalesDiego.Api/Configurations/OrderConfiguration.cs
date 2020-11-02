using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");
            builder.HasKey(p => p.IdOrder);
            builder.Property(p => p.IdOrder).HasColumnName("id_order").UseIdentityColumn();
            builder.Property(p => p.IdClient).HasColumnName("id_client");
            builder.Property(p => p.IdStateOrder).HasColumnName("id_state_order");
            builder.Property(p => p.DateOrder).HasColumnName("date_order");
            builder.HasOne(p => p.Client).WithMany(p => p.Orders).HasForeignKey(p => p.IdClient);
            builder.HasOne(p => p.StateOrder).WithMany(p => p.Orders).HasForeignKey(p => p.IdStateOrder);
        }
    }
}
