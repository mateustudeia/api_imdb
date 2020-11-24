using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Imdb.Infra.CrossCoutting.InversionOfControl
{
    public static class SwaggerDependency
    {
        public static void AddSwaggerDependency(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "IMDb API",
                        Version = "v1",
                        Description = "API REST criada com  ASP.NET Core 3.1",
                    });
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteActions();
            });
        }

        public static void UseSwaggerDependency(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDb API");
                c.DocumentTitle = "IMDb API";
                c.DocExpansion(DocExpansion.List);
            });
        }
    }
}
