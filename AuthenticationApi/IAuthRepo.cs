using AuthenticationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi
{
    public interface IAuthRepo
    {
        string GenerateJSONWebToken();

        User AuthenticateUser(User user);
    }
}
