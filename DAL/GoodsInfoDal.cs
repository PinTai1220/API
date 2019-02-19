using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Pub;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class GoodsInfoDal : I0peration_generic<GoodsInfo>
    {
        /// <summary>
        /// 商品添加
        /// </summary>
        /// <param name="t">商品对象</param>
        /// <returns></returns>
        public int Add(GoodsInfo t)
        {
            using (EFContext Context = new EFContext())
            {
                DbEntityEntry<GoodsInfo> dbEntityAdm = Context.Entry<GoodsInfo>(t);
                dbEntityAdm.State = System.Data.Entity.EntityState.Added;
                return Context.SaveChanges();
            }
        }
        /// <summary>
        ///禁用
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询所有商品
        /// </summary>
        /// <returns></returns>
        public List<GoodsInfo> SelectAll()
        {
            using (EFContext Context = new EFContext())
            {
                List<GoodsInfo> goods = (from s in Context.GoodsInfo
                                         select s).ToList();
                return goods;
            }
        }
        /// <summary>
        /// 根据商品id查询单个商品
        /// </summary>
        /// <param name="Id">商品id</param>
        /// <returns></returns>
        public GoodsInfo SelectById(int Id)
        {
            using (EFContext Context = new EFContext())
            {
                GoodsInfo good = (from s in Context.GoodsInfo
                                   where s.Equals(Id)
                                   select s).FirstOrDefault();
                return good;
            }
        }
        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Upt(GoodsInfo t)
        { 
             return DBHelper.ExecuteNonQuery($"update GoodInfo set GoodPhotoPath='{t.GoodPhotoPath}',GoodName='{t.GoodName}',GoodInfo='{t.GoodInfo}',GoodSum={t.GoodSum},GoodPrice={t.GoodPrice},GTID={t.GTID} where GoodId={t.GoodId}");           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int GoodStateUpt(GoodsInfo t)
        {
            int state;
            if (t.GoodState == 0)
                state = 1;
            else
                state = 0;
            return DBHelper.ExecuteNonQuery($"update GoodInfo set GoodState={state} where GoodId={t.GoodId}");
        }
    }
}
