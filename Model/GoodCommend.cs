using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    /// <summary>
    /// 商品评论
    /// </summary>
    [Table("GoodCommend")]
    public class GoodCommend
    {
        /// <summary>
        /// 标识列
        /// </summary>
        [Key]
        public int GoodCommendId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int GID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UID { get; set; }
        /// <summary>
        /// 用户评论
        /// </summary>
        public string CommendInfo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CommendCreateTime { get; set; }
    }
}
