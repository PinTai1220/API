using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class CourierBll
    {
        CourierDal Cdal = new CourierDal();
        public List<object> List(object[] obj)
        {
            return Cdal.SelectAll(obj);
        }
        public int Add(Courier courier)
        {
            courier.CourierCreateTime= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            courier.CourierNum= DateTime.Now.ToString("yyMMddhhmmssffff");
            return Cdal.Add(courier);
        }
    }
}
