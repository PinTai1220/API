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
                t.GoodCreateTime= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
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
        public List<object> SelectAll(object[] obj)
        {
            string str = obj[0].ToString();
            int IndexPage = IsNumber.IsNum(obj[1].ToString()) ? int.Parse(obj[1].ToString()) : 1;
            int IndexSize = IsNumber.IsNum(obj[2].ToString()) ? int.Parse(obj[2 ].ToString()) : 10;
            int state = IsNumber.IsNum(obj[3].ToString()) ? int.Parse(obj[3].ToString()) : 1;
            using (EFContext Context = new EFContext())
            {
                var goods = (from s in Context.GoodsInfo
                                         join b in Context.GoodType
                                         on s.GTID equals b.GoodTypeId
                                         orderby s.GoodId descending
                                         where s.GoodState.Equals(state)
                                         select new
                                         {
                                             GoodId=s.GoodId,
                                             GoodPhotoPath = s.GoodPhotoPath.Substring(0,IsSplit.Split(s.GoodPhotoPath)),
                                             GoodName = s.GoodName,
                                             GoodInfo = s.GoodInfo,
                                             GoodSellSum =s.GoodSellSum,
                                             GoodSum=s.GoodSum,
                                             GoodPrice = s.GoodPrice,
                                             GoodTypeName=b.GoodTypeName,
                                             href= "/detail/"+s.GoodId
                                         }).Where(m => str == "" ? true : m.GoodName.Contains(str) || m.GoodInfo.Contains(str) || m.GoodTypeName == str).Skip((IndexPage - 1) * IndexSize).Take(IndexSize).ToList();
                List<object> data = new List<object>();
                foreach (var item in goods)
                {
                    data.Add(item);
                }
                return data;
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
                                  where s.GoodId.Equals(Id)
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
        /// 商品上下架,删除修改
        /// </summary>
        /// <param name="id">商品id</param>
        /// <param name="state">修改后的状态(0下架,1上架,3删除)</param>
        /// <returns></returns>
        public int GoodStateUpt(int id,int state)
        {
            return DBHelper.ExecuteNonQuery($"update GoodsInfo set GoodState={state} where GoodId={id}");
        }
    }
}
