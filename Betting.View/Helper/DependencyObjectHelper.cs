using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup.Primitives;

namespace Betting.View
{

public static class DependencyObjectHelper
    {
        public static IEnumerable<FieldInfo> GetDependencyProperties(this Type type)
        {
            var flags = BindingFlags.Static |
                BindingFlags.FlattenHierarchy |
                BindingFlags.Public;

            return type.GetFields(flags)
                                 .Where(f => f.FieldType == typeof(DependencyProperty));
                                
        }


    }
}
