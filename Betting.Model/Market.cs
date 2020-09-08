using System;
using System.Collections.Generic;
using System.Text;
using Betting.Enum;

namespace Betting.Model
{
    public class Market
    {

        public MarketType Name { get; set; }

        [UtilityAttribute.Child]
        public List<Contract> Contracts { get; set; }


    }


}
