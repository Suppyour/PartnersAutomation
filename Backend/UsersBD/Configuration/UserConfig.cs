using Backend;
using Backend.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsersBD.Configuration
{
    class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(User.MaxLength);
        }
    }
}
