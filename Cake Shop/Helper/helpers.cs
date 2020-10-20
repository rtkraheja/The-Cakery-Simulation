using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cake_Shop.Helper
{
    public class helpers
    {
        public HttpClient ItemDetails()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44319");
            return client;
        }
        public HttpClient CartItems()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44322/");
            return client;
        }

        public HttpClient AuthenticationInfo()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44394/");
            return client;
        }

    }
}
