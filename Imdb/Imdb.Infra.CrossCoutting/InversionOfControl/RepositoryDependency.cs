using System;
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

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<IRepositoryUser, UserRepository>();
            services.AddScoped<IRepositoryVote, VoteRepository>();
            services.AddScoped<IRepositoryAdministrator, AdministratorRepository>();
            services.AddScoped<IRepositoryMovie, MovieRepository>();


        }
    }
}
