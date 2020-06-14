using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum.Betting;

namespace Betting.Model
{

    public class Recommendation
    {

        public string ParentKey { get; set; }

        public ContractType Key { get; set; }

        public DateTime Date { get; set; }

        public Side Side { get; set; }

        public int Value { get; set; }

    }
}
