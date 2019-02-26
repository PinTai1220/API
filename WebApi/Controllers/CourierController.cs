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
    //货单
    public class CourierController : ApiController
    {
        CourierBll Cbll = new CourierBll();
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="CourierNum">发货单号</param>
        /// <param name="OTGName">收货人</param>
        /// <param name="OTGPhone">联系方式</param>
        /// <param name="OTGAddress">收货地址</param>
        /// <param name="IndexPage">页码</param>
        /// <param name="IndexSize">记录数</param>
        /// <returns></returns>
        [HttpGet]
        public List<object> GetSome(string str,string PageIndex, string PageSize)
        {
            try
            {
                if (str == null)
                    str = "";
                object[] obj = { str, PageIndex,PageSize};
                return Cbll.List(obj);
            }
            catch (Exception)
            {

                return null;
            }
            
        }
        /// <summary>
        /// 发货信息添加
        /// </summary>
        /// <param name="courier"></param>
        /// <returns></returns>
        [HttpPost]
        public int Add(Courier courier)
        {
            return Cbll.Add(courier);
        }
    }
}
