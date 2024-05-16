using Microsoft.IdentityModel.Tokens;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaHutAPIWithAuth.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _secretkey;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _secretkey = configuration.GetSection("Tokens").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey));
        }
        public string GenerateJWTToken(User user)
        {
            string token = string.Empty;
            var claim = new List<Claim>()
            {
                new Claim("uid",user.Id.ToString()),
                new Claim("urole",user.Role)
            };
            var credentials = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claim, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }
    }
}
