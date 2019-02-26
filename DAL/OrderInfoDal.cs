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
    public class OrderInfoDal : I0peration_generic<OrderInfo>
    {
        public int Add(OrderInfo t)
        {
            throw new NotImplementedException();
        }
        public int Add(int UID,string OrderNum,string BuyGoodsAndSum,string OrderCreateTime)
        {
            return (int)DBHelper.ExecuteScalar($"declare @result int exec p_AddOrder {UID},{OrderNum},{BuyGoodsAndSum},{OrderCreateTime}");
        }
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<object> SelectAll(object[] obj)
        {
            using (EFContext Context = new EFContext())
            {
                string str = obj[0].ToString();
                int IndexPage = IsNumber.IsNum(obj[1].ToString()) ? int.Parse(obj[1].ToString()) : 1;
                int IndexSize = IsNumber.IsNum(obj[2].ToString()) ? int.Parse(obj[2].ToString()) : 10;
                int state = IsNumber.IsNum(obj[3].ToString()) ? int.Parse(obj[3].ToString()) : 1;
                var list = (from a in Context.OrderInfo
                           orderby a.OrderId descending
                           select a).Where(m => str == "" ? true : m.OTGAddress.Contains(str) || m.BuyGoodsAndSum.Contains(str) || m.OrderNum == str || m.OTGPhone == str).Where(m=>m.OrderState==state).ToList();
                List<object> data = new List<object>();
                foreach (var item in list)
                {
                    data.Add(item);
                }
                return data;
            }
        }

        public OrderInfo SelectById(int id)
        {
            using (EFContext Context = new EFContext())
            {
                OrderInfo Order = (from a in Context.OrderInfo
                                   where a.OrderId.Equals(id)
                                   select a).FirstOrDefault();
                return Order;
            }
        }

        public int Upt(OrderInfo t)
        {
            return DBHelper.ExecuteNonQuery($"update OrderInfo set OrderState={t.OrderState} where OrderId={t.OrderId}");
        }
    }
}
