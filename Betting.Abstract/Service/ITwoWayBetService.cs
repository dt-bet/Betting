using Betting.Abstract.Service;
using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface ITwoWayBetService : IBetService<ITwoWayPrediction, IBet, ITwoWayOdd>
    {

    }
}
