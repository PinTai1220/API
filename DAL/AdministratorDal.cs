using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Pub;
using System.Data.Entity.Infrastructure;

namespace DAL
{
    public class AdministratorDal : I0peration_generic<Administrator>
    {
        /// <summary>
        /// 管理员信息添加
        /// </summary>
        /// <param name="t">Administrator对象</param>
        /// <returns></returns>
        public int Add(Administrator t)
        {
            using (EFContext Context = new EFContext())
            {
                var jieguo = from s in Context.Administrator
                             select s;
                if(jieguo.FirstOrDefault()==null)
                {
                    Administrator administrator = new Administrator()
                    {
                        AdministratorAccount = t.AdministratorAccount,
                        AdministratorPwd = t.AdministratorPwd
                    };
                    DbEntityEntry<Administrator> dbEntityAdm = Context.Entry<Administrator>(administrator);
                    dbEntityAdm.State = System.Data.Entity.EntityState.Added;
                    Context.SaveChanges();
                    return 1;
                }
                else
                {
                    jieguo=jieguo.Where(a => a.AdministratorAccount == t.AdministratorAccount && a.AdministratorPwd == t.AdministratorPwd);
                    if (jieguo.FirstOrDefault() != null)
                        return 1;
                    else
                        return 0;
                }
            }
        }
        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Delete(Administrator t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <returns></returns>
        public List<object> SelectAll(object[] obj)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据id获取管理员对象
        /// </summary>
        /// <param name="Id">对象id</param>
        /// <returns></returns>
        public Administrator SelectById(int Id)
        {
            return DBHelper.GetList<Administrator>("select * from Administrator where AdministratorId=" + Id).ToList().FirstOrDefault();
        }
        /// <summary>
        /// 修改密码或修改发货信息
        /// </summary>
        /// <param name="t">Administrator对象</param>
        /// <returns></returns>
        public int Upt(Administrator t)
        {
            using (EFContext Context = new EFContext())
            {
                Context.Entry(t).State = System.Data.Entity.EntityState.Modified;
                if (t.AdministratorPwd == null)
                {
                    //修改发货信息禁止其他字段更新
                    Context.Entry(t).Property("AdministratorAccount").IsModified = false;
                    Context.Entry(t).Property("AdministratorPwd").IsModified = false;
                }
                else
                {
                    //修改密码禁止其他字段更新
                    Context.Entry(t).Property("AdministratorAccount").IsModified = false;
                    Context.Entry(t).Property("DeliveryName").IsModified = false;
                    Context.Entry(t).Property("DeliveryAddress").IsModified = false;
                    Context.Entry(t).Property("DeliveryPhone").IsModified = false;
                }
                return Context.SaveChanges();
            }
                
        }
    }
}
