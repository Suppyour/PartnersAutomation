using Backend.Entites;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configuration
{
    class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(User.MaxLength);
            builder.Property(b => b.Login)
                .IsRequired()
                .HasMaxLength(User.MaxLength);
            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(User.MaxLength);
        }
    }
}
