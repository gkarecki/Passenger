using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Extensions;
using Passenger.Infrastructure.Settings;

namespace Passenger.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;
        public JwtHandler (JwtSettings settings)
        {
            _settings = settings;
        }
        public JwtDTO CreateToken(string email, string role)
        {
            var now = DateTime.Now;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer32)
            };
            
            var expires = now.AddMinutes(_settings.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key)), SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.ExpiryMinutes),
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDTO {
                Token = token,
                Expires = expires.ToTimeStamp()
            };
        }
    }
}