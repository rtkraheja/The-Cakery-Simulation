using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

using CartApi.Models;
using CartApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;

        }

        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            _log4net.Info("Fetching All Items");
            var cartitems = _cartRepository.GetAllCartItems();
            return cartitems;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _log4net.Info("Fetching Item from Cart using id");
            Cart cart = _cartRepository.GetCartItem(id);
            return new OkObjectResult(cart);
        }

        //POST api/<CartController>
        [HttpPost]
        public IActionResult Post( Cart cart)
        {
            _log4net.Info(" Adding item to cart");
            using (var scope = new TransactionScope())
            {
                
                _cartRepository.Add(cart);
                scope.Complete();
                _log4net.Info("Item Added");
                return Ok();
            }

        }

        // PUT api/<CartController>
        [HttpPut]
        public IActionResult Put(Cart cart)
        {
            _log4net.Info("Updating Item");
            _cartRepository.Update(cart);
            return Ok();
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _log4net.Info("Deleting Item");
            _cartRepository.Remove(id);
            return Ok();
        }
    }
}
