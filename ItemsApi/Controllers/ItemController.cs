using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ItemsApi.Models;
using ItemsApi.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItemsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ItemController));
        private readonly IitemRepository _itemRepository;
        // GET: api/<ItemController>

        public ItemController(IitemRepository itemRepository)
        {
            _itemRepository = itemRepository;

        }
        [HttpGet]
        public IActionResult Get()
        {
            _log4net.Info("Fetching Items");
            var items = _itemRepository.GetAllItems();
            if (items.Count() == 0)
            {
                return NotFound();
            }
            return new OkObjectResult(items);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Item item = _itemRepository.getItem(id);
            return new OkObjectResult(item);
             
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
