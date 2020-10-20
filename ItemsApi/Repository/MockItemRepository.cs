
using ItemsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsApi.Repository
{
    public class MockItemRepository : IitemRepository
    {
        private List<Item> _itemList;
        public MockItemRepository()
        {
            _itemList = new List<Item>()
            {
                new Item()
                {
                    Id=1, Name= "A", Price=100, Description="it's A"
                },
                new Item()
                {
                    Id=2, Name= "B",  Price=200, Description="it's B"
                },
                new Item()
                {
                    Id=1, Name= "C",  Price=300, Description="it's C"
                }

            };
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _itemList;
        }

        public Item getItem(int id)
        {
            return _itemList.FirstOrDefault(c => c.Id == id);
        }
    }
}
