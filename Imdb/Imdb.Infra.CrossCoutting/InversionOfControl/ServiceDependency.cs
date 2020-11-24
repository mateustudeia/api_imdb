using Imdb.Domain.Interfaces;
using Imdb.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Imdb.Infra.CrossCoutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services )
        {
            services.AddScoped<IServiceUser, UserService>();
            services.AddScoped<IServiceVote, VoteService>();
            services.AddScoped<IServiceMovie, MovieService>();
            services.AddScoped<IServiceAdministrator, AdministratorService>();
        }
    }
}
