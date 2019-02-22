using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pub;
using Model;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class UserInfoDal : I0peration_generic<UserInfo>
    {
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="t">用户对象</param>
        /// <returns></returns>
        public int Add(UserInfo t)
        {
            UserInfo data = t as UserInfo;
            using (EFContext Context = new EFContext())
            {
                data.UserCraeteTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                DbEntityEntry<UserInfo> dbEntityUser = Context.Entry<UserInfo>(data);
                try
                {
                    return Context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        [Obsolete]
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 返回所有用户信息
        /// </summary>
        /// <param name="obj">参数数组(string 查询关键字,int 页码,int 记录数 )</param>
        /// <returns></returns>
        public List<object> SelectAll(object[] obj)
        {
            string str = obj[0].ToString();
            int PageIndex= IsNumber.IsNum(obj[1].ToString()) ? int.Parse(obj[1].ToString()) : 1;
            int PageSize = IsNumber.IsNum(obj[2].ToString()) ? int.Parse(obj[3].ToString()) : 10;
            using (EFContext Context = new EFContext())
            {
                var users = (from s in Context.UserInfo
                             join b in Context.TakeGoodsInfo
                             on s.UserId equals b.UID
                             select new
                             {
                                 UserAccount=s.UserAccount,
                                 PhotoPath=s.PhotoPath,
                                 UserName=s.UserName,
                                 PhoneNumber=s.PhoneNumber,
                                 Email=s.Email,
                                 TGName = b.TGName,
                                 TGAddress=b.TGAddress,
                                 TGPhone=b.TGPhone
                             }).Where(m=>str==""?true:m.UserAccount==str || m.UserName==str ||m.PhoneNumber==str||m.Email==str || m.TGName == str || m.TGPhone == str || m.TGAddress.Contains(str)).Reverse().Skip(( PageIndex- 1) * PageSize).Take(PageSize).ToList();
                List<object> data = new List<object>();
                foreach (var item in users)
                {
                    data.Add(item);
                }
                return data;
            }
        }
        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserInfo SelectById(int Id)
        {
            using (EFContext Context = new EFContext())
            {
                UserInfo user = (from s in Context.UserInfo
                                 where s.UserId.Equals(Id)
                                 select s).FirstOrDefault();
                return user;
            }
        }
        /// <summary>
        /// 修改用户信息或修改密码
        /// </summary>
        /// <param name="t">用户对象</param>
        /// <returns></returns>
        public int Upt(UserInfo t)
        {
            using (EFContext Context = new EFContext())
            {
                Context.Entry(t).State = System.Data.Entity.EntityState.Modified;
                if (t.UserPwd == null)
                {
                    //修改用户信息禁止其他字段更新
                    Context.Entry(t).Property("UserAccount").IsModified = false;
                    Context.Entry(t).Property("UserPwd").IsModified = false;
                    Context.Entry(t).Property("UserCraeteTime").IsModified = false;
                }
                else
                {
                    //修改密码禁止其他字段更新
                    Context.Entry(t).Property("UserAccount").IsModified = false;
                    Context.Entry(t).Property("PhotoPath").IsModified = false;
                    Context.Entry(t).Property("UserName").IsModified = false;
                    Context.Entry(t).Property("PhoneNumber").IsModified = false;
                    Context.Entry(t).Property("Email").IsModified = false;
                    Context.Entry(t).Property("Sex").IsModified = false;
                    Context.Entry(t).Property("UserCraeteTime").IsModified = false;
                }
                return Context.SaveChanges();
            }
        }
    }
}
