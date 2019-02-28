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
        TakeGoodsInfoDal addinfo = new TakeGoodsInfoDal();
        public int Add(GoodsInfo goods)
        {
            goods.GoodCreateTime= DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return Gdal.Add(goods);
        }
        public List<object> SelectAll(object[] obj)
        {
            return Gdal.SelectAll(obj);
        }
        public object SelectById(int id,int uid)
        {
            try
            {
                GoodsInfo good = Gdal.SelectById(id);
                TakeGoodsInfo ainfo = addinfo.SelectById(uid);
                string serverpath= System.Web.HttpContext.Current.Server.MapPath("/Imgs");
                if (ainfo == null)
                    ainfo = new TakeGoodsInfo();
                ainfo.TGAddress = "收货信息未设置";

                List<Path> paths = new List<Path>();
                string[] phonos = good.GoodPhotoPath.Split('-');
                string newpath = "";
                foreach (var item in phonos)
                {
                    newpath = serverpath + item;
                    paths.Add(new Path() { src = newpath });
                }
                var data = new {
                    GoodId=good.GoodId,
                    GoodName=good.GoodName,
                    GoodInfo=good.GoodInfo,
                    GoodPrice=good.GoodPrice,
                    GoodSum=good.GoodSum,
                    GoodPhotoPath=paths,
                    address=ainfo.TGAddress,
                };
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private class Path
        {
            public string src { get; set; }
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
