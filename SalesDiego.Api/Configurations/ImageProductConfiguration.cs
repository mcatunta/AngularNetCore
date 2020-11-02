using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class ImageProductConfiguration : IEntityTypeConfiguration<ImageProduct>
    {
        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.ToTable("image_product");
            builder.HasKey(p => p.IdImageProduct);
            builder.Property(p => p.IdImageProduct).HasColumnName("id_image_product").UseIdentityColumn();
            builder.Property(p => p.IdProduct).HasColumnName("id_product");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Active).HasColumnName("active");
            builder.HasOne(p => p.Product).WithMany(p => p.ImageProducts).HasForeignKey(p => p.IdProduct);
        }
    }
}
