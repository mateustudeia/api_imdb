using Microsoft.EntityFrameworkCore;
using Imdb.Domain.Entities;
using Imdb.Infra.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imdb.Infra.Context
{
    public class ImdbContext : DbContext
    {
        public DbSet<User> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host = localhost; Database = imdb; Username = imdb; Password = imdb");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("imdb");
            modelBuilder.ApplyConfiguration(new UserMap());


        }
    }
}
