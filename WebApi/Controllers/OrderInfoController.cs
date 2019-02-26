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
    public class OrderInfoController : ApiController
    {
        OrderInfoBll OrderBll = new OrderInfoBll();
        /// <summary>
        /// 订单添加
        /// </summary>
        /// <param name="UID">用户id</param>
        /// <param name="BuyGoodsAndSum">购买的商品和数量</param>
        /// <returns></returns>
        [HttpPost]
        public int Add(int UID, string BuyGoodsAndSum)
        {
            try
            {
                return OrderBll.Add(UID, BuyGoodsAndSum);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据条件查询订单信息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet]
        public string List(string str,string PageIndex,string PageSize,string state)
        {
            try
            {
                if (str == null)
                    str = "";
                object[] obj = { str, PageIndex, PageSize, state };
                var data = OrderBll.List(obj);
                //return OrderBll.List(obj);
                string datastr = JsonConvert.SerializeObject(data);
                return datastr;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
