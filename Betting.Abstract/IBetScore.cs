using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract
{
    public interface IBetScore
    {
        string Source { get; }
        string Key { get; }
        int AvgAmtOverWager { get; }
        int Count { get; }

        DateTime Date { get; }
        int AvgWager { get; }

        double Summarise();
    }
}
