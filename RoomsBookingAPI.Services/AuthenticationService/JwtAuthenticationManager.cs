using Microsoft.IdentityModel.Tokens;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services.View_Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RoomsBookingAPI.Services.AuthenticationService
{
    public class JwtAuthenticationManager : IjwtAuthenticationManager
    {
        readonly string Jwt_Key = "ThisismySecretKey";
        readonly string Jwt_Issuer = "Test.com";

        public string GenerateJSONWebToken(UserDetails userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt_Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim("Roles", userInfo.UserType.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(Jwt_Issuer,
                Jwt_Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}
