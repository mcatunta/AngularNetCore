using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesDiego.Api.Entities;

namespace SalesDiego.Api.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(p => p.IdUser);
            builder.Property(p => p.IdUser).HasColumnName("id_user").UseIdentityColumn();
            builder.Property(p => p.UserName).HasColumnName("username");
            builder.Property(p => p.Password).HasColumnName("password");
        }
    }
}
