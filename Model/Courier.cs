using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Courier")]
    public class Courier
    {
        /// <summary>
        /// 标识列
        /// </summary>
        [Key]
        public int CourierId { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public int OID { get; set; }
        /// <summary>
        /// 快递号
        /// </summary>
        public string CourierNum { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CourierCreateTime { get; set; }
    }
}
