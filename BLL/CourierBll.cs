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
        public static List<object> List(string str, int IndexPage, int IndexSize)
        {
            return CourierDal.List(str, IndexPage, IndexSize);
        }
    }
}
