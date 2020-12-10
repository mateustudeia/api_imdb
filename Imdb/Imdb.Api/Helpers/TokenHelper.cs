using Imdb.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Imdb.Api.Helpers
{
    public class TokenHelper
    {
        public static string GenerateUserToken(User user, string tokenKey)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Name, user.Name.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = "Bearer " + tokenHandler.WriteToken(securityToken);


            return token;
        }

    }
}
