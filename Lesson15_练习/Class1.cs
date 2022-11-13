using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15_练习
{
    public static class Class1
    {
        public static IEnumerable<TSource> Ppp<TSource>(this IEnumerable<TSource> sources, Func<TSource, bool> ddd)
        {
            List<TSource> tsourceList = new List<TSource>();
            
            foreach (TSource source in sources)
            {
                if (ddd(source))
                { 
                    tsourceList.Add(source);
                }
            }
            return tsourceList;
        }
    }
}
