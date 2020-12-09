using Microsoft.EntityFrameworkCore;
using Imdb.Domain.Entities;
using Imdb.Infra.Data.Mapping;

namespace Imdb.Infra.Data.Context
{
    public class ImdbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<VoteUserMovie> Vote { get; set; }
        public DbSet<Administrator> Administrator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host = localhost; Database = imdb_dotnet; Username = postgres; Password = postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("imdb");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImdbContext).Assembly);

        }
    }
}
