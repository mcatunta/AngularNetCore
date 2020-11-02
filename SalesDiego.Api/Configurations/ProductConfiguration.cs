using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(p => p.IdProduct);
            builder.Property(p => p.IdProduct).HasColumnName("id_product").UseIdentityColumn();
            builder.Property(p => p.IdCategoryProduct).HasColumnName("id_category_product");
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Description).HasColumnName("description");
            builder.Property(p => p.Price).HasColumnName("price");
            builder.Property(p => p.Image).HasColumnName("image");
            builder.HasOne(p => p.CategoryProduct).WithMany(p => p.Products).HasForeignKey(p => p.IdCategoryProduct);
        }
    }
}
