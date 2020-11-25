using Optional;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract.Service
{
    public interface IPredictionService: IPredictionService<IPrediction, IOdd>
    {
    }

    public interface IPredictionService<TPrediction, TOdd>
        where TPrediction : IPrediction
        where TOdd : IOdd
    {
        IEnumerable<(Option<TPrediction, Exception> had, TOdd odd)> MakeThreeWayPredictions(IEnumerable<TOdd> odds);
    }
}
