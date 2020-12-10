using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Imdb.Infra.CrossCoutting.InversionOfControl
{
    public static class SwaggerDependency
    {
        public static void AddSwaggerDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "IMDb API",
                        Version = "v1",
                        Description = "API REST criada com  ASP.NET Core 3.1",
                    });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Insert the JWT this way: Bearer {your token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new string[] {}
                    }
                });

                options.IgnoreObsoleteActions();
                options.IgnoreObsoleteActions();

                options.CustomSchemaIds(x => x.FullName);

                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocumentPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");

                if (File.Exists(xmlDocumentPath))
                {
                    options.IncludeXmlComments(xmlDocumentPath);
                }

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
