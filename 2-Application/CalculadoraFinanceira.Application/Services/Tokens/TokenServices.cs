using CalculadoraFinanceira.Application.Generic;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalculadoraFinanceira.Application.Services.Tokens
{
    public class TokenServices : ITokenServices
    {
        private readonly AppSettings _appSettings;

        public TokenServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string NewToken()
        {
            var dataDeExpiracao = DateTime.Now.AddDays(1);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Guid.NewGuid().ToString())
                }),
                Expires = dataDeExpiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenObj = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(tokenObj);

            return tokenHandler.WriteToken(tokenObj);
        }
    }
}