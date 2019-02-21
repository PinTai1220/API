using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub
{
    public interface I0peration_generic<T> where T:class
    {
        List<T> SelectAll();
        T SelectById(int id);
        int Add(T t);
        int Upt(T t);
        int Delete(int Id);
    }
}
