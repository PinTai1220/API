using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    public class GoodTypeController : ApiController
    {
        private GoodTypeBll gbll = new GoodTypeBll();
        [HttpGet]
        public string TypeList()
        {
            return JsonConvert.SerializeObject(gbll.GetList());
        }
    }
}
