using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("AddressInfo")]
    //地址
    public class AddressInfo
    {
        [Key]
        public int AddressId { get; set; }
        /// <summary>
        /// 地点名称
        /// </summary>
        public string AddressName { get; set; }
        /// <summary>
        /// 上级地点id
        /// </summary>
        public int ParentId { get; set; }
    }
}
