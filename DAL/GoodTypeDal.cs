using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pub;
using Model;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class GoodTypeDal : I0peration_generic<GoodType>
    {
        /// <summary>
        /// 商品类型添加
        /// </summary>
        /// <param name="t">商品类型对象</param>
        /// <returns></returns>
        public int Add(GoodType t)
        {
            using (EFContext Context = new EFContext())
            {
                DbEntityEntry<GoodType> dbEntityAdm = Context.Entry<GoodType>(t);
                dbEntityAdm.State = System.Data.Entity.EntityState.Added;
                return Context.SaveChanges();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t">商品类型id</param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            //查询此类型是否有商品
            int count = (int)DBHelper.ExecuteScalar("select count(1) from GoodsInfo where GoodId=" + Id);
            if (count == 0)
                return DBHelper.ExecuteNonQuery("delete from goodsinfo where goodid=" + Id);
            else
                return 0;
        }
        /// <summary>
        /// 查询所有商品类型
        /// </summary>
        /// <returns></returns>
        public List<GoodType> SelectAll()
        {
            return DBHelper.GetList<GoodType>("select * from Goodtype");
        }

        public GoodType SelectById(int Id)
        {
            return DBHelper.GetList<GoodType>("select * from goodtype where GoodTypeId=" + Id).ToList().FirstOrDefault();
        }

        public int Upt(GoodType t)
        {
            throw new NotImplementedException();
        }
    }
}
