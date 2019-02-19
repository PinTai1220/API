using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class AdministratorBll
    {
        AdministratorDal adal = new AdministratorDal();
        public int Login(Administrator t)
        {
            return adal.Add(t);
        }
        public int Upt(Administrator t)
        {
            return adal.Upt(t);
        }
    }
}
