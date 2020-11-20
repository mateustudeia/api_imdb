using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace Imdb.Infra.CrossCoutting.InversionOfControl
{
    public static class JwtDependency
    {
        public static void AddJwtDependency(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.ASCII.GetBytes(CrossCuttingConstants.SECRET_KEY_HASH)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }

        public static void UseJwtDependency(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
