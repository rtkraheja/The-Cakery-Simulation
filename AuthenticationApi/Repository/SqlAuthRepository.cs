using AuthenticationApi.Data;
using AuthenticationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Model
{
    public class SqlAuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _db;
        public SqlAuthRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
