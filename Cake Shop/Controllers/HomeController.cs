using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cake_Shop.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Cake_Shop.Helper;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using StackExchange.Redis;

namespace Cake_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [TempData]
        private string StatusMessage { get; set; }
        
        helpers obj = new helpers();
        public async Task<IActionResult> Index()
        {
            List<Item> items = new List<Item>();
            HttpClient client = obj.ItemDetails();
            HttpResponseMessage res = await client.GetAsync("api/Item");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<List<Item>>(result);
            }
            return View(items);
        }

        

        public IActionResult login(int id)
        {
            StatusMessage = "";
            TempData["ItemId"] = id;
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userModel)
        {
            HttpClient client = obj.AuthenticationInfo();
            var contentType = new MediaTypeWithQualityHeaderValue
        ("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            /*UserDetail userModel = new UserDetail();
            userModel.Id = 1;
            userModel.UserName = "Anuj";
            userModel.Password = "1234";*/

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData,
        System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync
        ("/api/Authentication", contentData).Result;

            string stringJWT = response.Content.
        ReadAsStringAsync().Result;

            JWT jwt = JsonConvert.DeserializeObject
        <JWT>(stringJWT);
            if (jwt.Token == null)
            {
                StatusMessage = "Invalid Username and Password";
                TempData.Keep();
                return RedirectToAction("login");
            }

            HttpContext.Session.SetString("token", jwt.Token);

            /*ViewBag.Message = "User logged in successfully!";

            return View("Index");*/
            //return Content("User Logged in Successfully");
            TempData.Keep();
            return RedirectToAction("GetCartItems");
        }

        
        public async Task<IActionResult> GetCartItems()
        {
            Cart cart = new Cart();
            var a = Convert.ToInt32(TempData["ItemId"]);

            Item items = new Item();
            HttpClient client = obj.ItemDetails();
            HttpResponseMessage res = await client.GetAsync("api/Item/" + a);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                items = JsonConvert.DeserializeObject<Item>(result);
            }

            cart.ItemId = items.Id;
            cart.item = items;
            cart.ItemName = items.Name;
            TempData.Keep();
            return View( cart);
        }

        [HttpPost]
        public IActionResult GetCartItems(Cart cart)
        {

            HttpClient client = obj.CartItems();
            var postTask = client.PostAsJsonAsync<Cart>($"api/Cart", cart);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Content("Not Working");

            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class JWT
    {
        public string Token { get; set; }
    }
}
