using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Abstract.Service
{

    public interface ITwoWayPredictionService: IPredictionService<ITwoWayPrediction, ITwoWayOdd>
    {
    }
}
