using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .HasColumnName("id");
            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)");
            builder.Property(u => u.Gender)
                .HasColumnName("gender")
                .HasColumnType("varchar(20)");
            builder.Property(u => u.DateOfBirth)
                .HasColumnName("date_of_birth");
            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasColumnType("varchar(100)");
            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnName("password_hash")
                .HasColumnType("varchar(100)");
            builder.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasColumnName("password_salt")
                .HasColumnType("varchar(100)");
            builder.Property(u => u.IsDeleted)
                .IsRequired()
                .HasColumnName("is_deleted");
        }
    }
}
