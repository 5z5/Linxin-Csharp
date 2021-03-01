using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IDAL;
using System.Reflection;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IUser CreateUser()
        {
            string className = AssemblyName + "." + db + "User";
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IArticle CreateArticle()
        {
            string className = AssemblyName + "." + db + "Article";
            return (IArticle)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserLinkArticle CreateUserLinkArticle()
        {
            string className = AssemblyName + "." + db + "UserLinkArticle";
            return (IUserLinkArticle)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
