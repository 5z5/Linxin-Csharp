using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Model;

namespace BLL
{
    public class UserLinkArticleManager
    {
        IUserLinkArticle iuserLinkArticle = DataAccess.CreateUserLinkArticle();
        public IEnumerable<UserLinkArticleData> GetUserLinkArticle()
        {
            var userLinkArticle = iuserLinkArticle.GetUserLinkArticle();
            return userLinkArticle;
        }
    }
}
