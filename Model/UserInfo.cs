using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //用户
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string UserAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        public string PhotoPath { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 注册时间(yyyy-MM-dd hh:mm:ss)
        /// </summary>
        public string UserCraeteTime { get; set; }
    }
}
