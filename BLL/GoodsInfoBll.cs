using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class GoodsInfoBll
    {
        GoodsInfoDal Gdal = new GoodsInfoDal();
        public int Add(GoodsInfo goods)
        {
            goods.GoodCreateTime= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return Gdal.Add(goods);
        }
        public List<object> SelectAll(object[] obj)
        {
            return Gdal.SelectAll(obj);
        }
        public GoodsInfo SelectById(int id)
        {
            return Gdal.SelectById(id);
        }
        public int Upt(GoodsInfo good)
        {
            return Gdal.Upt(good);
        }
        public int GoodStateUpt(int id,int state)
        {
            return Gdal.GoodStateUpt(id, state);
        }
    }
}
