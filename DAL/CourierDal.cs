﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Pub;

namespace DAL
{
    /// <summary>
    /// 货物信息查看
    /// </summary>
    public class CourierDal
    {
        public static List<object> List(string str, int IndexPage, int IndexSize)
        {
            using (EFContext Context = new EFContext())
            {
                var list = (from a in Context.Courier
                            join b in Context.OrderInfo
                            on a.OID equals b.OrderId
                            join c in Context.ShoppingCart
                            on b.SCID equals c.ShoppingCartId
                            join d in Context.GoodsInfo
                            on c.GID equals d.GoodId
                            join e in Context.GoodType
                            on d.GTID equals e.GoodTypeId
                            select new
                            {
                                CourierId = a.CourierId,
                                CourierNum = a.CourierNum,
                                OrderId = b.OrderId,
                                OTGName = b.OTGName,
                                OTGPhone = b.OTGPhone,
                                OTGAddress = b.OTGAddress,
                                OrderNum = b.OrderNum,
                                OGoodName = b.OGoodName,
                                GoodTypeName = e.GoodTypeName,
                                GoodPhotoPath = d.GoodPhotoPath.Substring(0, d.GoodPhotoPath.IndexOf('.'))
                            }).Where(m => str== "" ? true : m.CourierNum == str || m.OTGName == str || m.OTGPhone == str || m.OTGAddress.Contains(str) || m.OrderNum == str || m.OGoodName == str || m.GoodTypeName == str).Skip((IndexPage - 1) * IndexSize).Take(IndexSize).ToList();
                List<object> olist = new List<object>();
                foreach (var item in list)
                {
                    olist.Add(item);
                }
                return olist;
            }
        }
    }
}
