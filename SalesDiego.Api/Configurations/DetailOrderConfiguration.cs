using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class DetailOrderConfiguration : IEntityTypeConfiguration<DetailOrder>
    {
        public void Configure(EntityTypeBuilder<DetailOrder> builder)
        {
            builder.ToTable("detail_order");
            builder.HasKey(p => p.IdDetailOrder);
            builder.Property(p => p.IdDetailOrder).HasColumnName("id_detail_order").UseIdentityColumn();
            builder.Property(p => p.IdOrder).HasColumnName("id_order");
            builder.Property(p => p.IdProduct).HasColumnName("id_product");
            builder.Property(p => p.Quantity).HasColumnName("quantity");
            builder.Property(p => p.Price).HasColumnName("price");
            builder.HasOne(p => p.Product).WithMany(p => p.DetailOrders).HasForeignKey(p => p.IdProduct);
            builder.HasOne(p => p.Order).WithMany(p => p.DetailOrders).HasForeignKey(p => p.IdOrder);
        }
    }
}
