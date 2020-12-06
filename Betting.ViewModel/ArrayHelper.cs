using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betting.ViewModel
{
    class ArrayHelper
    {

        public static T[][] Rearrange<T>(T[][] a)
        {
            var max = a.Max(a => a.Length);
            T[][] list = new T[max][];

            for (int i = 0; i < max; i++)
            {
                list[i] = new T[a.Length];
            }

            for (int i = 0; i < a.Length; i++)
            {
                int j = 0;
                try
                {
                    using var c = a[i].ToList().GetEnumerator();
                    while (c.MoveNext() && 0 <= j++)
                        list[j - 1][i] = c.Current;
                }
                catch (Exception ex)
                {
                }
            }

            return list;

        }
    }
}
