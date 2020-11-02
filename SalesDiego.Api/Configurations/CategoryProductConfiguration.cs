using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.ToTable("category_product");
            builder.HasKey(p => p.IdCategoryProduct);
            builder.Property(p => p.IdCategoryProduct).HasColumnName("id_category_product").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("name");
        }
    }
}
