using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UtilityInterface.NonGeneric;

namespace Betting.ViewModel
{
    class ViewModelFinder
    {
        public static KeyValuePair<string, KeyValuePair<string, object>>[] Select(string viewModelAssembly = "Betting.ViewModel")
        {
            var tt = Assembly.Load(viewModelAssembly).GetTypes();
            //var xx =tt[6].GetCustomAttribute<ViewModel.ViewModel>();
            var ss = tt
                   .Where(type => type.GetCustomAttribute<ViewModel>() != null)
                   .ToArray();

            var xs = ss
                   .SelectMany(type => Splat.Locator.Current.GetServices(type).Select(a => (a, type))).ToArray();

            return xs.Select(st =>
            {
                var (service, type) = st;
                var name = typeof(IName).IsAssignableFrom(type) ?
                                                (service as IName).Name :
                                                 type.Name;
                return new KeyValuePair<string, KeyValuePair<string, object>>(
                    type.Name,
                    new KeyValuePair<string, object>(name, service));
            }).ToArray();
        }
    }
}
