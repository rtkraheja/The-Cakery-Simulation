using AuthenticationApi.Model;
using AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApi
{
    public class AuthProvider : IAuthRepo
    {
        private IConfiguration _config;
        IAuthRepository _user;
        public AuthProvider(IConfiguration config, IAuthRepository user)
        {
            _config = config;
            _user = user;
        }

        public User AuthenticateUser(User user)
        {
            var userdetailslist = _user.GetAll();
            foreach (var i in userdetailslist)
            {
                if (i.username == user.username && i.password == user.password)
                    return user;
            }
            return null;
        }

        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
