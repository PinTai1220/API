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
    public class ShoppingCartController : ApiController
    {
        ShoppingCartBll Sbll = new ShoppingCartBll();
    }
}
