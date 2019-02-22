using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("SalesRecord")]
    public class SalesRecord
    {
        /// <summary>
        /// 标识列
        /// </summary>
        [Key]
        public int SalesRecordId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int GID { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public int OID { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public double SGoodPrice { get; set; }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int SGoodNum { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double SumPrice { get; set; }
        /// <summary>
        /// 类型(已付,已退)
        /// </summary>
        public int SType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string SCreateTime { get; set; }
    }
}
