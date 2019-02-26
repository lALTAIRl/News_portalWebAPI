//using Microsoft.IdentityModel.Tokens;
//using News_portal.BLL.Interfaces;
//using News_portal.DAL.Entities;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace News_portal.BLL.Services
//{
//    public class AuthentificateService : IAuthentificationService
//    {
//        private readonly IConfiguration _configuration;

//        public AuthentificateService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public Task<string> GenerateJWTToken(string email, ApplicationUser user)
//        {
//            var claims = new List<Claim>
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, email),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                new Claim(ClaimTypes.NameIdentifier, user.Id)
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

//            var token = new JwtSecurityToken(
//                _configuration["JwtIssuer"],
//                _configuration["JwtIssuer"],
//                claims,
//                expires: expires,
//                signingCredentials: creds
//            );

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
