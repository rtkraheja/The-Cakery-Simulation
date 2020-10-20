using AuthenticationApi;
using AuthenticationApi.Controllers;
using AuthenticationApi.Model;
using AuthenticationApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NunitTestItem
{
    [TestFixture]
    public class AuthenticationTest
    {
        private Mock<IAuthRepository> _user;
        private Mock<IConfiguration> _config;
        private Mock<IAuthRepo> _auth;
        private AuthenticationController _controller;

        [SetUp]
        public void Setup()
        {
            _config = new Mock<IConfiguration>();
            _user = new Mock<IAuthRepository>();
            _auth = new Mock<IAuthRepo>();
            _controller = new AuthenticationController(_config.Object, _user.Object, _auth.Object);
        }

        [Test]
        public void Login_WhenCalled_ReturnsOk()
        {
            User user = new User()
            {
                Id = 1,
                username = "Ritik",
                password = "1234"
            };
            _auth.Setup(r => r.AuthenticateUser(It.IsAny<User>())).Returns(user);
            _auth.Setup(r => r.GenerateJSONWebToken()).Returns("Token");

            var result = _controller.Login(user);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void Login_WhenCalled_ReturnsUnAuthorized()
        {
            User user = new User()
            {
                Id = 1,
                username = "Ritik",
                password = "1234"
            };
            _auth.Setup(r => r.AuthenticateUser(It.IsAny<User>())).Returns(() => null);
            _auth.Setup(r => r.GenerateJSONWebToken()).Returns("Token");

            var result = _controller.Login(user);

            Assert.That(result, Is.InstanceOf<UnauthorizedResult>());
        }
    }
}
