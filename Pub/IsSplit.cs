using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub
{
    public static class IsSplit
    {
        public static int Split(string str)
        {
            if (str.Contains("-"))
                return str.IndexOf('-');
            else
                return str.Length;
        }
    }
}
