using Imdb.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Imdb.Infra.CrossCoutting.InversionOfControl
{
    public static class PostgreSqlDependency
    {
        public static void AddPostgreSqlDependency(this IServiceCollection services )
        {
            services.AddDbContext<ImdbContext>();
        }
    }
}
