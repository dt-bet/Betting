using Betting.Abstract;
using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IBetService
    {
        IEnumerable<IBet> MakeBets(IEnumerable<IOdd> odds);
    }
}
