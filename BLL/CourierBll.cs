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
        public static List<object> list(string CourierNum, string OTGName, string OTGPhone,string OTGAddress, int IndexPage, int IndexSize)
        {
            return CourierDal.list(CourierNum, OTGName, OTGPhone, OTGAddress, IndexPage, IndexSize);
        }
    }
}
