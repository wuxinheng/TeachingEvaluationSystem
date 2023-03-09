using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingEvaluationSystem.Comom
{
    public class Page<T>
    {
        public Page()
        {
            Data = new List<T>();
        }
        public int Index { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public List<T> Data { get; set; }
        public int TotalPgae { get; set; }
    }
}
