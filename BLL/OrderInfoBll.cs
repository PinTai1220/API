using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class OrderInfoBll
    {
        OrderInfoDal OrderDal = new OrderInfoDal();
        public int Add(int UID, string BuyGoodsAndSum)
        {
            string OrderCreateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            Random random = new Random();
            string OrderNum = DateTime.Now.ToString("yyMMddhhmmssfff")+random.Next(10,99);
            return OrderDal.Add(UID, OrderNum, BuyGoodsAndSum, OrderCreateTime);
        }
        public List<object> List(object[] obj)
        {
            return OrderDal.SelectAll(obj);
        }
        public OrderInfo SelectById(int id)
        {
            return OrderDal.SelectById(id);
        }
        public int Upt(OrderInfo t)
        {
            //if(t.OrderState==2)
            //if(t.OrderState==5)
            return OrderDal.Upt(t);
        }
    }
}
