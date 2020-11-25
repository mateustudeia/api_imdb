using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Infra.Data.Mapping
{
    public class VoteUserMovieMap : IEntityTypeConfiguration<VoteUserMovie>
    {
        public void Configure(EntityTypeBuilder<VoteUserMovie> builder)
        {
            builder.ToTable("vote_user_movie");

            builder.HasKey(v => new { v.MovieId, v.UserId });

            builder
                .Property(v => v.Id)
                .HasColumnName("id");

            builder
                .Property(v => v.VoteScore)
                .HasColumnName("vote_score");

            builder
                .Property(v => v.UserId)
                .HasColumnName("user_id");

            builder
                .Property(v => v.MovieId)
                .HasColumnName("movie_id");

        }
    }
}
