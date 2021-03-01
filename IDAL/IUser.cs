using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IUser
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(int? id);
        void RemoveUser(Users user);
        void AddUser(Users user);
        void EditUser(Users user);
        Users GetUserByName(string name);
    }
}
