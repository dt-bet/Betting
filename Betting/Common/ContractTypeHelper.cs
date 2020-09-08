using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Betting.Enum;

namespace Betting.Common
{
    public static class ContractTypeHelper
    {
        public static Dictionary<ContractType, decimal> ExtractHDAOdds<T>(T match, Func<T, decimal> home, Func<T, decimal> draw, Func<T, decimal> away)
        {
            return new Dictionary<ContractType, decimal>
            {
             { ContractType.Home, home(match)},
             { ContractType.Draw ,draw(match)},
             { ContractType.Away,away(match)},
            };
        }


        public static ContractType ToContract(this string result) => result switch
        {
            "H" => ContractType.Home,
            "D" => ContractType.Draw,
            "A" => ContractType.Away,
            null => ContractType.None,
            _ => throw new System.ComponentModel.InvalidEnumArgumentException("not h/a/d")
        };


        public static IEnumerable<KeyValuePair<string, decimal[]>> OrderByContract(this IEnumerable<KeyValuePair<string, decimal[]>> contracts) => contracts.OrderBy(x =>
        {
            int en;
            try
            {
                en = (int)System.Enum.Parse(typeof(ContractType), x.Key, true);
            }
            catch
            {
                return int.MaxValue;
            }
            return en;
        });

    }
}
