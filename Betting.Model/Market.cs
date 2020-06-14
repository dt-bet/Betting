using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum.Betting;

namespace Betting.Model
{
    public class Market
    {

        public MarketType Name { get; set; }

        [UtilityAttribute.Child]
        public List<Contract> Contracts { get; set; }


    }


}
