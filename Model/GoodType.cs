using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //商品类型
    [Table("GoodType")]
    public class GoodType
    {
        [Key]
        public int GoodTypeId { get; set; }
        //类型名称
        public string GoodTypeName { get; set; }
        //创建时间
        public string GoodTypeCreateTime { get; set; }
    }
}
