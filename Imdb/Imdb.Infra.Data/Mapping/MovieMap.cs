using Imdb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Imdb.Infra.Data.Mapping
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.ToTable("movie");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(m => m.Titulo)
                .IsRequired()
                .HasColumnName("titulo")
                .HasColumnType("varchar(50)");

            builder.Property(m => m.Ano)
                .IsRequired()
                .HasColumnName("ano");

            builder.Property(m => m.TempoDuracao)
                .IsRequired()
                .HasColumnName("tempo_duracao")
                .HasColumnType("interval");

            builder.Property(m => m.Enredo)
                .IsRequired()
                .HasColumnName("enredo");

            builder.Property(m => m.Diretor)
                .IsRequired()
                .HasColumnName("diretor");

            builder.Property(m => m.Genero)
                .IsRequired()
                .HasColumnName("genero");

            builder.Property(m => m.Atores)
                .IsRequired()
                .HasColumnName("atores");

        }
    }
}
