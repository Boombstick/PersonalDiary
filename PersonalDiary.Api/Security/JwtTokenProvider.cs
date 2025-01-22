using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using PersonalDiary.Domain.Models.Users;
using PersonalDiary.Application.Interfaces;

namespace PersonalDiary.Api.Security
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly TokenManagement _tokenManagement;

        public JwtTokenProvider(IOptions<TokenManagement> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }

        public string GetToken(User user)
        {
            var jwtToken = new JwtSecurityToken(
                issuer: _tokenManagement.Issuer,
                audience: _tokenManagement.Audience,
                claims:
                [
                    new Claim("id", user.Id.ToString()),
                    new Claim("name", user.UserName!)
                ],
                expires: DateTime.Now.AddHours(5),
                signingCredentials: new SigningCredentials(_tokenManagement.SecurityKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
