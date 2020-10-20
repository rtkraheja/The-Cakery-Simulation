using CartApi.Controllers;
using CartApi.Models;
using CartApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NunitTestItem
{
    class CartTest
    {
        private Mock<ICartRepository> _cartlist;
        private CartController _controller;
       // private Mock<IConfiguration> _config;

        [SetUp]
        public void Setup()
        {
            _cartlist = new Mock<ICartRepository>();
            //_config = new Mock<IConfiguration>();
            _controller = new CartController(_cartlist.Object);
        }

        [Test]
        public void Get_WhenCalled_ReturnsListOfCartItems()
        {

            _cartlist.Setup(repo => repo.GetAllCartItems()).Returns(new List<Cart> {new Cart()
                {
                    Id = 1,
                    ItemId = 5,
                    Quantity = 10
                } });

            var result = _controller.Get();


            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Post_WhenCalled_ReturnsOk()
        {

            _cartlist.Setup(repo => repo.Add(It.IsAny<Cart>())).Verifiable();

            var result = _controller.Post(new Cart { });


            //Assert.AreEqual(200,result.StatusCode);
            Assert.That(result, Is.TypeOf<OkResult>());
        }

        [Test]
        public void Get_WhenCalled_pecificItem()
        {

            _cartlist.Setup(repo => repo.GetCartItem(1)).Returns(new Cart()
                {
                    Id = 1,
                    ItemId = 5,
                    Quantity = 10
                } );

            var result = _controller.Get(1);


            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }


    }
}
