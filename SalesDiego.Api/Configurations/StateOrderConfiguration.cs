using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class StateOrderConfiguration : IEntityTypeConfiguration<StateOrder>
    {
        public void Configure(EntityTypeBuilder<StateOrder> builder)
        {
            builder.ToTable("state_order");
            builder.HasKey(p => p.IdStateOrder);
            builder.Property(p => p.IdStateOrder).HasColumnName("id_state_order").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("name");
        }
    }
}
