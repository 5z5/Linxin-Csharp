using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DALFactory;
using Model;
using System.Security;

namespace BLL
{
    public class UserManager
    {
        IUser iuser = DataAccess.CreateUser();
        public IEnumerable<Users> GetUsers()
        {
            var users = iuser.GetUsers();
            return users;
        }
        public Users GetUserById(int? id)
        {
            Users user = iuser.GetUserById(id);
            return user;
        }
        public void RemoveUser(Users user)
        {
            iuser.RemoveUser(user);
        }
        public void AddUser(Users user)
        {
            iuser.AddUser(user);
        }
        public void EditUser(Users user)
        {
            iuser.EditUser(user);
        }
        public Users GetUsersByName(String name)
        {
            var user = iuser.GetUserByName(name);
            return user;
        }
    }
}
