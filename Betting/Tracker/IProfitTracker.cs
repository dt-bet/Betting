using System;
using System.Collections.Generic;
using System.Text;
using UtilityEnum.Betting;
using UtilityStruct;

namespace Betting
{
    public interface IProfitTracker
    {
        void Init(DateTime start, NodaMoney.Money initialvalue);
        void UpdateWeek(byte week);
        void ExecuteBet(DateTime date, ContractType type);
        void MakeBet(DateTime date, double arb, Probability price, Side side);
    }
}
