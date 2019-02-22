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
    }
}
