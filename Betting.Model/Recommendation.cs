using System;
using System.Collections.Generic;
using System.Text;
using Betting.Enum;

namespace Betting.Model
{

    public class Recommendation
    {

        public string ParentKey { get; set; }

        public ContractType Key { get; set; }

        public DateTime Date { get; set; }

        public TradeSide Side { get; set; }

        public int Value { get; set; }

    }
}
