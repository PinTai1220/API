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
        public int Get()
        {
            return 1;
        }
        public int Add(UserInfo user)
        {
            return ubll.Add(user);
        }
    }
}
