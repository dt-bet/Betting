using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum;
using Betting.Enum;

namespace Betting.Model
{

    public class Result
    {

        public string ParentKey { get; set; }

        public ContractType Key { get; set; }

        public DateTime Date { get; set; }

        public string Team { get; set; }

        //public string AwayTeam { get; set; }

        //public int HomeTeamResult { get; set; }

        public Resolution Value { get; set; }
    }


}
