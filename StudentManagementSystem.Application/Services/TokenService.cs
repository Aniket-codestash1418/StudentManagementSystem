using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Application.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtSettings> _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            this._jwtSettings = jwtSettings;
        }
        public string GenerateToken(string username)
        {
            try
            {
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Value.Key!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var token = new JwtSecurityToken(
                            issuer: _jwtSettings.Value.Issuer,
                            audience: _jwtSettings.Value.Audience,
                            claims: claims,
                            expires: DateTime.Now.AddMinutes(_jwtSettings.Value.ExpiryMinutes),
                            signingCredentials: creds
 );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
