using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class GoodsInfo
    {
        [Key]
        public int GoodId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodName { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        public int GTID { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string GoodInfo { get; set; }
        /// <summary>
        /// 商品图片路径
        /// </summary>
        public string GoodPhotoPath { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public double GoodPrice { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodSum { get; set; }
        /// <summary>
        /// 商品销售量
        /// </summary>
        public int GoodSellSum { get; set; }
        /// <summary>
        /// 商品状态(上架，下架(默认))
        /// </summary>
        public int GoodState { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public string GoodCreateTime { get; set; }
    }
}
