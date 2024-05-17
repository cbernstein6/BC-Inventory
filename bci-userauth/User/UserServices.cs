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


        public Task<User> GetUser(User user){
            User first = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password ==  user.Password);
            if(first == null) 
                throw new Exception("User not found");
                
            return Task.FromResult<User>(first);
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