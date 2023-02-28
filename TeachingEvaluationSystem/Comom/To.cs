using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.Comom
{
    public static class To
    {
        public static long ToLong(this int number)
        {
           return Convert.ToInt64(number);
        }
    }
}
