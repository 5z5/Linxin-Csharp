using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class DBContextFactory
    {
        public static LinxinaccessEntities CreateDbContext()
        {
            LinxinaccessEntities dbContext = (LinxinaccessEntities)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new LinxinaccessEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
