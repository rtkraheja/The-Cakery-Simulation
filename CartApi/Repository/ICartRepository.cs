
using CartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Repository
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAllCartItems();

        void Add(Cart cartItem);
        void Remove(int cartItemId);

        void Update(Cart cart);

        Cart GetCartItem(int id);
        
    }
}
