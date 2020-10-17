using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Mapping
{
    public class AdministratorMap : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.ToTable("administrator");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .IsRequired()
                .HasColumnName("id");
            builder.Property(a => a.UserId)
                .IsRequired()
                .HasColumnName("user_id");
            builder.Property(a => a.CreationDate)
                .IsRequired()
                .HasColumnName("creation_date");
            builder.Property(a => a.Profession)
                .HasColumnName("profession");
            builder.Property(a => a.Education)
                .HasColumnName("education");
            builder.Property(a => a.IsDisabled)
                .IsRequired()
                .HasColumnName("is_disabled");


            builder.HasOne(a => a.User)
                .WithOne();

        }
            
    }
}
