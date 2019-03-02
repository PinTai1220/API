using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class GoodTypeBll
    {
        private GoodTypeDal Gdal = new GoodTypeDal();
        public List<object> GetList()
        {
            return Gdal.SelectAll(null);
        }
        public int Addtype(GoodType t)
        {
            return Gdal.Add(t);
        }
        public int Upt(GoodType t)
        {
            return Gdal.Upt(t);
        }
    }
}
