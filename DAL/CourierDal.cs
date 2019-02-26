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
    /// <summary>
    /// 货物信息查看
    /// </summary>
    public class CourierDal:I0peration_generic<Courier>
    {
        
        public int Add(Courier t)
        {
            using (EFContext Context = new EFContext())
            {
                DbEntityEntry<Courier> dbEntityAdm = Context.Entry<Courier>(t);
                dbEntityAdm.State = System.Data.Entity.EntityState.Added;
                return Context.SaveChanges();
            }
        }
        [Obsolete]
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<object> SelectAll(object[] obj)
        {
            using (EFContext Context = new EFContext())
            {
                string str = obj[0].ToString();
                int PageIndex = IsNumber.IsNum(obj[1].ToString()) ? int.Parse(obj[1].ToString()) : 1;
                int PageSize = IsNumber.IsNum(obj[2].ToString()) ? int.Parse(obj[3].ToString()) : 10;
                var list = (from a in Context.Courier
                            join b in Context.OrderInfo
                            on a.OID equals b.OrderId
                            orderby a.CourierId descending
                            select new
                            {
                                CourierId = a.CourierId,
                                CourierNum = a.CourierNum,
                                OrderId = b.OrderId,
                                OTGName = b.OTGName,
                                OTGPhone = b.OTGPhone,
                                OTGAddress = b.OTGAddress,
                                OrderNum = b.OrderNum,
                                BuyGoodsAndSum = b.BuyGoodsAndSum
                            }).Where(m => str == "" ? true : m.CourierNum == str || m.OTGName == str || m.OTGPhone == str || m.OTGAddress.Contains(str) || m.OrderNum == str || m.BuyGoodsAndSum.Contains(str)).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
                List<object> olist = new List<object>();
                foreach (var item in list)
                {
                    olist.Add(item);
                }
                return olist;
            }
        }
        [Obsolete]
        public Courier SelectById(int id)
        {
            throw new NotImplementedException();
        }
        [Obsolete]
        public int Upt(Courier t)
        {
            throw new NotImplementedException();
        }
    }
}
