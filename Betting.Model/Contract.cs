using System;
using System.Collections.Generic;
using System.Text;
using Betting.Enum;

namespace Betting.Model
{
    public class Contract
    {
        public ContractType Name { get; set; }
        public string Condition { get; set; }


        [UtilityAttribute.Child]
        public List<Price> Bids { get; set; }


        [UtilityAttribute.Child]
        public List<Price> Offers { get; set; }
    }
}
