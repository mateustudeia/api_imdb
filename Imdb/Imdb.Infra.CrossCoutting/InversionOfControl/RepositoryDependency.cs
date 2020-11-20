using Imdb.Domain.Entities;
using Imdb.Domain.Interfaces;
using Imdb.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Imdb.Infra.CrossCoutting.InversionOfControl
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User, int>, Repository<User, int>>();
            services.AddScoped<IRepository<Vote, int>, Repository<Vote, int>>();
            services.AddScoped<IRepository<Movie, int>, Repository<Movie, int>>();
            services.AddScoped<IRepository<Administrator, int>, Repository<Administrator, int>>();

            services.AddScoped<IRepositoryUser, UserRepository>();
            services.AddScoped<IRepositoryVote, VoteRepository>();
            services.AddScoped<IRepositoryAdministrator, AdministratorRepository>();
            services.AddScoped<IRepositoryMovie, MovieRepository>();
        }
    }
}
