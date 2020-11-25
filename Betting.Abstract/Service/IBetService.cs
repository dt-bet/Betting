using Betting.Abstract.Service;
using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IBetService: IBetService<IPrediction, IBet, IOdd>
    {

    }

    public interface IBetService<TPrediction, TBet, TOdd>
        where TPrediction : IPrediction
        where TBet : IBet
        where TOdd : IOdd
    {
        IEnumerable<Optional.Option<TBet, Exception>> MakeBets(IEnumerable<(TPrediction, TOdd)> predictions);
    }
}
