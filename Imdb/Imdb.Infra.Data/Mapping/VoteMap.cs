using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Infra.Data.Mapping
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("vote_user_movie");

            builder.HasKey(v => v.Id);

            builder
                .Property(v => v.Id)
                .HasColumnName("id");

            builder
                .Property(v => v.VoteScore)
                .HasColumnName("vote_score");
            builder
                .HasOne(v => v.User)
                .WithMany(u => u.VoteMovie)
                .HasForeignKey(v => v.UserId);

            builder
                .Property(v => v.UserId)
                .HasColumnName("user_id");

            builder
                .HasOne(v => v.Movie)
                .WithMany(v => v.VoteMovie)
                .HasForeignKey(v => v.MovieId);

            builder
                .Property(v => v.MovieId)
                .HasColumnName("movie_id");





        }
    }
}
