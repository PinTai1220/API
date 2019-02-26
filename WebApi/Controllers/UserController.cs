using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        UserInfoBll ubll = new UserInfoBll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">查询关键字</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">记录数</param>
        /// <returns>list<object>集合</returns>
        [HttpGet]
        public List<object> GetAll(string str, int PageIndex, int PageSize)
        {
            try
            {
                if (str == null)
                    str = "";
                object[] obj = { str, PageIndex, PageSize };
                return ubll.List(obj);
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>用户对象</returns>
        [HttpGet]
        public UserInfo GetById(int id)
        {
            return ubll.GetById(id);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>受影响行数</returns>
        [HttpPost]
        public int Add(UserInfo user)
        {
            return ubll.Add(user);
        }
        /// <summary>
        /// 用户信息修改(个人信息或密码修改)
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>受影响行数</returns>
        [HttpPost]
        public int Upt(UserInfo user)
        {
            return ubll.Upt(user);
        }
    }
}
