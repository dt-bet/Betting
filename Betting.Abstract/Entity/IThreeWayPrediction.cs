using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IThreeWayPrediction : ITwoWayPrediction
    {
        Guid Player3Id { get; }
        uint Player3Prediction { get; }
    }
}