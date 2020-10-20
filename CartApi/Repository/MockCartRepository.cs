

using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Repository
{
    public class MockCartRepository : ICartRepository
    {
        private List<Cart> _cartItemList;
        public MockCartRepository()
        {
            _cartItemList = new List<Cart>()
            {
                


            };
        }

        public void Add(Cart cartItem)
        {
            _cartItemList.Add(cartItem);
        }

        public IEnumerable<Cart> GetAllCartItems()
        {
            return _cartItemList.ToList();
        }

        public void Remove(int cartItemId)
        {
            var item = _cartItemList.Where(c => c.Id == cartItemId).FirstOrDefault();
            _cartItemList.Remove(item);
        }

        public void Update(Cart cart)
        {
            
            
        }
        public Cart GetCartItem(int id)
        {
            return new Cart();
        }
    }
}
