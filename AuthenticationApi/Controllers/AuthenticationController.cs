using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationApi.Model;
using AuthenticationApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthenticationController));
        private readonly IConfiguration _config;
        private readonly IAuthRepository _user;
        private readonly IAuthRepo _auth;

        public AuthenticationController(IConfiguration config, IAuthRepository user , IAuthRepo auth)
        {
            _config=config;
            _user = user;
            _auth = auth;
        }

        [HttpPost]
        // [HttpGet]
        public IActionResult Login(User user)
        {
            _log4net.Info("Authentication Started");
            
            IActionResult response = Unauthorized();
            var tempuser =_auth.AuthenticateUser(user);

            if (tempuser != null)
            {
                var tokenString = _auth.GenerateJSONWebToken();
                response = Ok(new { token = tokenString });
            }
            return response;
        }
       /* private string GenerateJSONWebToken()
        {
            _log4net.Info("Generating Token");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User user)
        {

            _log4net.Info("Authenticating user from database");
            var userlist = _user.GetAll();
            foreach (var i in userlist)
            {
                if (i.username == user.username && i.password == user.password)
                {
                    _log4net.Info("User Authenticated");
                    return user;
                }
            }
            _log4net.Info("Authentication Failed");
            return null;

        }
       */
    }
}
