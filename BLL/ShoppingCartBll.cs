using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class ShoppingCartBll
    {
        ShoppingCartDal Sdal = new ShoppingCartDal();
        public int Add(ShoppingCart t)
        {
            t.ShoppingCartState = 1;
            t.ShoppingCartCreateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return Sdal.Add(t);
        }
    }
}
