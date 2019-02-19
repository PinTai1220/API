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
            using (EFContext Context = new EFContext())
            {
                t.UserCraeteTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                DbEntityEntry<UserInfo> dbEntityUser = Context.Entry<UserInfo>(t);
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
        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 返回所有用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> SelectAll()
        {
            using (EFContext Context = new EFContext())
            {
                List<UserInfo> users = (from s in Context.UserInfo
                                        select s).ToList();
                return users;
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
