using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bci_userauth.UserModel;
using bci_userauth.DataContext;

namespace bci_userauth.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserDbContext _context;
        public UserServices(UserDbContext context){
            _context = context;
        }
        public Task<User> AddUser(User user){
            throw new NotImplementedException();
        }


        public Task<User> GetUser(int id){
            User user = _context.Users.Find(id);

            return Task.FromResult<User>(user);
        }


        public Task<IEnumerable<User>> GetUsers(){
            throw new NotImplementedException();
        }
        public Task RemoveUser(int id){
            throw new NotImplementedException();
        }
        public Task<User> UpdateUser(User user){
            throw new NotImplementedException();
        }
    }
}