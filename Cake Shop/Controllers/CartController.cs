using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cake_Shop.Helper;
using Cake_Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cake_Shop.Controllers
{
    public class CartController : Controller
    {
        helpers obj = new helpers();
        // GET: CartController
        public async Task<IActionResult> Index()
        {
       
            List<Cart> cartitems = new List<Cart>();
            HttpClient client = obj.CartItems();
            HttpResponseMessage res = await client.GetAsync("api/Cart");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                cartitems = JsonConvert.DeserializeObject<List<Cart>>(result);
            }
           

            return View(cartitems);
        }

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            

            Cart cart = new Cart();
            HttpClient client = obj.CartItems();
            HttpResponseMessage res = await client.GetAsync("api/Cart/" + id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                cart = JsonConvert.DeserializeObject<Cart>(result);
            }
            var itemid = cart.ItemId;

            Item item = new Item();
            HttpClient client1 = obj.ItemDetails();
            HttpResponseMessage res1 = await client1.GetAsync("api/Item/" + itemid);
            if (res1.IsSuccessStatusCode)
            {
                var result = res1.Content.ReadAsStringAsync().Result;
                item = JsonConvert.DeserializeObject<Item>(result);
            }

            cart.item = item;

            return View(cart);
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit(Cart cart)
        {
            HttpClient client = obj.CartItems();
            var postTask = client.PutAsJsonAsync<Cart>($"api/Cart/", cart);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        // GET: CartController/Delete/5
        public  ActionResult Delete(int id)
        {
            HttpClient client = obj.CartItems();
            client.BaseAddress = new Uri("https://localhost:44322/api/");
            var deleteTask = client.DeleteAsync("Cart/" + id.ToString());
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
