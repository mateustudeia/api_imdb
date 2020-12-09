using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("id")
                .IsRequired();
            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            builder.Property(u => u.Gender)
                .HasColumnName("gender")
                .HasColumnType("CHAR(20)");
            builder.Property(u => u.DateOfBirth)
                .HasColumnName("date_of_birth")
                .IsRequired();
            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("CHAR(100)")
                .IsRequired();
            builder.Property(u => u.Role)
                .HasColumnName("role")
                .HasColumnType("CHAR(20)")
                .IsRequired();
            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash")
                .IsRequired();
            builder.Property(u => u.PasswordSalt)
                .HasColumnName("password_salt")
                .IsRequired();
            builder.Property(u => u.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired();

            builder.HasIndex(u => u.Email).HasName("idx_user_email");
        }
    }
}
