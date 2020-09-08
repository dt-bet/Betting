using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Common
{
    internal static class LazyEx
    {
        public static Lazy<T> Create<T>(this Func<T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return new Lazy<T>(func);
        }
    }
}
