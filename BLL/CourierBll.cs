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
    }
}
