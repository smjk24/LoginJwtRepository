using Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.IRepository
{
    public interface IUserServiceRepository
    {
        Task<Response> Authenticate(string username, string password);
        Task<Account> GetUserById(int userid);
    }
}
