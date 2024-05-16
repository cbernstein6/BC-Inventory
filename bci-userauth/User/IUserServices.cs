using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bci_userauth.UserModel;

namespace bci_userauth.Services
{
    public interface IUserServices
    {
        public Task<User> AddUser(User user);
        public Task<User> GetUser(int id);
        public Task<IEnumerable<User>> GetUsers();
        public Task RemoveUser(int id);
        public Task<User> UpdateUser(User user);
    }
}