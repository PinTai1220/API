using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Pub;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class ShoppingCartDal : I0peration_generic<ShoppingCart>
    {
        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="t">购物车对象(接收字段:UID 用户id int,GID 商品id int,Num 购买数量 int )</param>
        /// <returns></returns>
        public int Add(ShoppingCart t)
        {
            
            using(EFContext Context = new EFContext())
            {
                DbEntityEntry<ShoppingCart> dbEntityAdm = Context.Entry<ShoppingCart>(t);
                dbEntityAdm.State = System.Data.Entity.EntityState.Added;
                return Context.SaveChanges();
            }
        }
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<object> SelectAll(object[] obj)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public int Upt(ShoppingCart t)
        {
            throw new NotImplementedException();
        }
    }
}
