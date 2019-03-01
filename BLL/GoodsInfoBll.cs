using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Pub;

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
            var data = Gdal.SelectAll(obj);
            List<object> newlist = new List<object>();
            foreach (var item in data)
            {
                PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(item);
                PropertyDescriptor path = pdc.Find("GoodId", true);
                string GoodId = path.GetValue(item).ToString();

                PropertyDescriptor path1 = pdc.Find("GoodPhotoPath", true);
                string oldGoodPhotoPath = path1.GetValue(item).ToString();
                string GoodPhotoPath = "http://localhost:54217/Imgs/" + oldGoodPhotoPath.Substring(0, IsSplit.Split(oldGoodPhotoPath));

                PropertyDescriptor path2 = pdc.Find("GoodName", true);
                string GoodName = path2.GetValue(item).ToString();

                PropertyDescriptor path3 = pdc.Find("GoodInfo", true);
                string GoodInfo = path3.GetValue(item).ToString();

                PropertyDescriptor path4 = pdc.Find("GoodSellSum", true);
                string GoodSellSum = path4.GetValue(item).ToString();

                PropertyDescriptor path5 = pdc.Find("GoodSum", true);
                string GoodSum = path5.GetValue(item).ToString();

                PropertyDescriptor path6 = pdc.Find("GoodPrice", true);
                string GoodPrice = path6.GetValue(item).ToString();

                PropertyDescriptor path7 = pdc.Find("GoodTypeName", true);
                string GoodTypeName = path7.GetValue(item).ToString();

                PropertyDescriptor path8 = pdc.Find("href", true);
                string href = path8.GetValue(item).ToString();
                var newdata = new
                {
                    GoodId,
                    GoodPhotoPath,
                    GoodName,
                    GoodInfo,
                    GoodSellSum,
                    GoodSum,
                    GoodPrice,
                    GoodTypeName,
                    href
                };
                newlist.Add(newdata);
            }
            
            return newlist;
        }
        public object SelectById(int id,int uid)
        {
            try
            {
                GoodsInfo good = Gdal.SelectById(id);
                TakeGoodsInfo ainfo = addinfo.SelectById(uid);
                if (ainfo == null)
                    ainfo = new TakeGoodsInfo();
                ainfo.TGAddress = "收货信息未设置";

                List<Path> paths = new List<Path>();
                string[] phonos = good.GoodPhotoPath.Split('-');
                string newpath = "";
                foreach (var item in phonos)
                {
                    newpath = "http://localhost:54217/Imgs/" + item;
                    paths.Add(new Path() { src = newpath });
                }
                var data = new {
                    good.GoodId,
                    good.GoodName,
                    good.GoodInfo,
                    good.GoodPrice,
                    good.GoodSum,
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
