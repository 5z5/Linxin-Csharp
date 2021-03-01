using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    class SqlUser: IUser
    {
        LinxinaccessEntities db = DBContextFactory.CreateDbContext();
        public IEnumerable<Users> GetUsers()
        {
            var users = db.Users.ToList();
            return users;
        }
        public Users GetUserById(int? id)
        {
            var user = db.Users.Find(id);
            return user;
        }
        public void RemoveUser(Users user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public void AddUser(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void EditUser(Users user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
        public Users GetUserByName(string name)
        {
            var user = db.Users.Where(o => o.user_name == name).FirstOrDefault();
            return user;
        }
    }
}
