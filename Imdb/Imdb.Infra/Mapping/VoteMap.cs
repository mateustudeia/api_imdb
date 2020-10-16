using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Mapping
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("vote_user_movie");

            builder.HasKey(v => v.Id);

            builder
                .Property(v => v.VoteNote)
                .HasColumnName("vote_note");
            builder
                .HasOne(v => v.User)
                .WithMany(u => u.VoteMovie)
                .HasForeignKey(v => v.UserId);
            builder
                .HasOne(v => v.Movie)
                .WithMany(v => v.VoteMovie)
                .HasForeignKey(v => v.MovieId);




        }
    }
}
