
using ItemsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsApi.Repository
{
    public interface IitemRepository
    {
        Item getItem(int id);
        IEnumerable<Item> GetAllItems();
    }
}
