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
        /// <returns></returns>
        [HttpGet]
        public List<object> SelectPart(string str, string PageIndex, string PageSize)
        {
            try
            {
                object[] obj = { str, PageIndex, PageSize };
                return Gbll.SelectAll(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 根据id查询商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public GoodsInfo SelectById(int id)
        {
            return Gbll.SelectById(id);
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
