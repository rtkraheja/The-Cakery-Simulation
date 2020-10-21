
using CartApi.Data;
using CartApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartApi.Repository
{
    public class SqlCartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;

        public SqlCartRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public void Add(Cart cartItem)
        {
            Cart temp = new Cart();
            temp.ItemId = cartItem.ItemId;
            temp.Quantity = cartItem.Quantity;
            temp.ItemName = cartItem.ItemName;
            _db.Cart.Add(temp);
            _db.SaveChanges();
        }

        public IEnumerable<Cart> GetAllCartItems()
        {
            return _db.Cart.ToList();
        }

        public void Remove(int cartItemId)
        {
            var item = _db.Cart.Where(c => c.Id == cartItemId).FirstOrDefault();
            _db.Remove(item);
            _db.SaveChanges();

        }

        public void Update(Cart cart)
        {
            _db.Update(cart);
            _db.SaveChanges();
        }
        public Cart GetCartItem(int id)
        {
            return _db.Cart.Find(id);
        }
    }
}

