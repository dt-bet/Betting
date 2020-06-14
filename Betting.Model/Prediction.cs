using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityEnum.Betting;
using UtilityStruct;

namespace Betting.Model
{


    public class Prediction
    {
        public string ParentKey { get; set; }

        public ContractType Key { get; set; }


        public DateTime Date { get; set; }

        public Probability Value { get; set; }

    }



}
