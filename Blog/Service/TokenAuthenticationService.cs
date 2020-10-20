using Blog.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class TokenAuthenticationService : IAuthenticateService
    {
   
        private readonly TokenManagement _tokenManagement;
        public TokenAuthenticationService(IOptions<TokenManagement> tokenManagement)
        {
            _tokenManagement = tokenManagement.Value;
        }
        public string GetToken(string username)
        {
            string token = string.Empty;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
