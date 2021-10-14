using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unikrowd.Bussiness.CommonModels;

namespace Unikrowd.Bussiness.Utils
{
    public static class JwtHelper
    {
        public static string GenerateJwtTokenAgent(GenerateJwtModel model, string secret, string issuer)
        {
            var claims = new[]
            {
                new Claim("Id", model.Id.ToString()),
                new Claim(ClaimTypes.Role , model.Role.ToString()),
                new Claim(ClaimTypes.Name , model.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
                issuer,
                claims,
                expires: DateTime.UtcNow.AddHours(7).Date.AddDays(1),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}