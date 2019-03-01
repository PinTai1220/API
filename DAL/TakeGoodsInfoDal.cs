using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Pub;

namespace DAL
{
    public class TakeGoodsInfoDal : I0peration_generic<TakeGoodsInfo>
    {
        public int Add(TakeGoodsInfo t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<object> SelectAll(object[] obj)
        {
            throw new NotImplementedException();
        }

        public TakeGoodsInfo SelectById(int id)
        {
            using (EFContext Context = new EFContext())
            {
                return (from a in Context.TakeGoodsInfo
                        where a.UID.Equals(id)
                        select a).FirstOrDefault();
            }
        }

        public int Upt(TakeGoodsInfo t)
        {
            throw new NotImplementedException();
        }
    }
}
