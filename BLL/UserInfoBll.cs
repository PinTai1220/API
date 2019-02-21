using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class UserInfoBll
    {
        UserInfoDal user = new UserInfoDal();
        public int Add(UserInfo use)
        {
            use.UserCraeteTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return user.Add(use);
        }
    }
}
