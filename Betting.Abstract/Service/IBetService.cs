using Betting.Abstract.Service;
using System;
using System.Collections.Generic;

namespace Betting.Abstract
{
    public interface IBetService
    {
        IEnumerable<Optional.Option<IBet, Exception>> MakeBets(IEnumerable<IOdd> odds);
    }
}
