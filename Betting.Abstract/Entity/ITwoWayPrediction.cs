using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface ITwoWayPrediction : IPrediction
    {
        Guid Player1Id { get; }
        string Player1Name { get; }
        uint Player1Prediction { get; }
        Guid Player2Id { get; }
        string Player2Name { get; }
        uint Player2Prediction { get; }

        string ToString();
    }
}