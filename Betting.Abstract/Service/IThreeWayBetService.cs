using Betting.Abstract.Service;
using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IThreeWayBetService : IBetService<IThreeWayPrediction, IBet, IThreeWayOdd>
    {

    }
}
