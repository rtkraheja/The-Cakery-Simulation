using AuthenticationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Model
{
    public interface IAuthRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User Get(int id);
        IEnumerable<User> GetAll();
    }
}
