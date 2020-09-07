
using System;
using System.Collections.Generic;
using Betting.Enum;
using UtilityStruct;

namespace Betting.Model
{


    public struct Price
    {

        public string ParentKey { get; set; }

        public ContractType Key { get; set; }

        public DateTime Time { get; set; }

        public PriceSource Source { get; set; }

        public PriceSide Side { get; set; }

        public Odd Value { get; set; }

        public double Volume { get; set; }

        public int Depth { get; set; }
    }
}
