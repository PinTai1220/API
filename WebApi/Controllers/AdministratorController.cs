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
    public class AdministratorController : ApiController
    {
        AdministratorBll abll = new AdministratorBll();
        /// <summary>
        /// 商场管理员登录
        /// </summary>
        /// <param name="AdministratorAccount"></param>
        /// <param name="AdministratorPwd"></param>
        /// <returns></returns>
        public int Get(string AdministratorAccount, string AdministratorPwd)
        {
            Administrator administrator = new Administrator
            {
                AdministratorAccount = AdministratorAccount,
                AdministratorPwd = AdministratorPwd
            };
            return abll.Login(administrator);
        }
        /// <summary>
        /// 密码修改和发货信息修改
        /// </summary>
        /// <param name="administrator"></param>
        /// <returns></returns>
        public int Put(Administrator administrator)
        {
            return abll.Upt(administrator);
        }
    }
}
