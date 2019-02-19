using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //订单
    public class OrderInfo
    {
        [Key]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号（日期yyyyMMddhhmmss）
        /// </summary>
        public string OrderNum { get; set; }
        /// <summary>
        /// 购物车id
        /// </summary>
        public int SCID { get; set; }
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
