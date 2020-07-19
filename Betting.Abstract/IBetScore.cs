using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IBetScore : UtilityInterface.NonGeneric.Database.IGuid
    {
        Guid Guid { get; set; }

        string Source { get; }

        string Key { get; }

        int AvgAmtOverWager { get; }

        int Count { get; }

        DateTime Date { get; }

        int AvgWager { get; }

        double Summarise();
    }
}
