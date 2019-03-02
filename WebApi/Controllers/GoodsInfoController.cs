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
    public class GoodsInfoController : ApiController
    {
        GoodsInfoBll Gbll = new GoodsInfoBll();
        /// <summary>
        /// 商品添加
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        public int Add(GoodsInfo goods)
        {
            return Gbll.Add(goods);
        }
        /// <summary>
        /// 商品查询
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>json数据</returns>
        [HttpGet]
        public string SelectPart(string str, string PageIndex, string PageSize,string state)
        {
            //try
            //{
                if (str == null)
                    str = "";
                object[] obj = { str, PageIndex, PageSize,state };
                List<object> data= Gbll.SelectAll(obj);
                string datastr = JsonConvert.SerializeObject(data);
                return datastr;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }

        /// <summary>
        /// 根据id查询商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns>json数据</returns>
        public string SelectByIdGood(int Id)
        {
            return JsonConvert.SerializeObject(Gbll.SelectByIdGood(Id));
        }
        /// <summary>
        /// 根据商品id查询商品,用户id查询获取用户收货信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpGet]
        public string SelectById(int id,int uid)
        {
            string jsonstr= JsonConvert.SerializeObject(Gbll.SelectById(id, uid));
            return jsonstr;
        }
        /// <summary>
        /// 商品信息修改
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        public int Upt(GoodsInfo goods)
        {
            return Gbll.Upt(goods);
        }
        /// <summary>
        /// 商品状态修改
        /// </summary>
        /// <param name="id">商品id</param>
        /// <param name="state">状态码(0下架,1上架,2删除)</param>
        /// <returns></returns>
        [HttpPost]
        public int GoodStateUpt(int id,int state)
        {
            return Gbll.GoodStateUpt(id, state);
        }
    }
}
