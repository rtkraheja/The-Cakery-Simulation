
using ItemsApi.Data;
using ItemsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsApi.Repository
{
    public class SqlItemRepository : IitemRepository
    {
        private readonly ApplicationDbContext _db;

        public SqlItemRepository(ApplicationDbContext db)
        {
            _db = db;
          
        }

        public IEnumerable<Item> GetAllItems()
        {

            return _db.Items.ToList();
        }

        public Item getItem(int id)
        {
            return _db.Items.Find(id);
        }
    }
}
