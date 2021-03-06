﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //订单
    [Table("OrderInfo")]
    public class OrderInfo
    {
        /// <summary>
        /// 标识列
        /// </summary>
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号（日期yyyyMMddhhmmss+两位随机数）
        /// </summary>
        public string OrderNum { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string OTGName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string OTGPhone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string OTGAddress { get; set; }
        /// <summary>
        /// 购买的商品和数量
        /// </summary>
        public string BuyGoodsAndSum { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 创建时间yyyy-MM-dd hh:mm:ss
        /// </summary>
        public string OrderCreateTime { get; set; }
    }
}
