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
        UserInfoDal userdal = new UserInfoDal();
        public int Add(UserInfo use)
        {
            use.UserCraeteTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return userdal.Add(use);
        }
        public List<object> List(object[] obj)
        {
            return userdal.SelectAll(obj);
        }
        public UserInfo GetById(int id)
        {
            return userdal.SelectById(id);
        }
        public int Upt(UserInfo use)
        {
            return userdal.Upt(use);
        }
        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public int Login(string Account, string Pwd)
        {
            return userdal.Login(Account, Pwd);
        }
    }
}
