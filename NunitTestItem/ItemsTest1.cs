using ItemsApi.Controllers;
using ItemsApi.Models;
using ItemsApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NunitTestItem
{
    public class Tests
    {
        private Mock<IitemRepository> _item;
        private ItemController _controller;
        //private Mock<IConfiguration> _config;

        [SetUp]
        public void Setup()
        {
            _item = new Mock<IitemRepository>();
           // _config = new Mock<IConfiguration>();
            _controller = new ItemController(_item.Object);
        }

        [Test]
        public void Get_WhenCalled_ReturnsListOfMenuItems()
        {

            _item.Setup(repo => repo.GetAllItems()).Returns(new List<Item> {new Item()
                {
                    Id = 1,
                    Name = "Fruit Cake",
                    Description = "Fruit Loaded Cake",
                    Price = 500
                } });

            var result = _controller.Get();


            Assert.That(result , Is.TypeOf<OkObjectResult>());
        }
        [Test]
        public void Get_WhenCalled_ReturnsItemOfMenuItems()
        {

            _item.Setup(repo => repo.getItem(1)).Returns(new Item()
                {
                    Id = 1,
                    Name = "Fruit Cake",
                    Description = "Fruit Loaded Cake",
                    Price = 500
                } );

            var result = _controller.Get(1);


            Assert.That(result, Is.TypeOf<OkObjectResult>());
        }


    }
}