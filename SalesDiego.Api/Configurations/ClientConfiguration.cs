using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");
            builder.HasKey(p => p.IdClient);
            builder.Property(p => p.IdClient).HasColumnName("id_client").UseIdentityColumn();
            builder.Property(p => p.Name).HasColumnName("name");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.Password).HasColumnName("password");
        }
    }
}
