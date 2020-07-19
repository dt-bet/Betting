using System;
using System.Collections.Generic;
using System.Text;
using UtilityInterface.NonGeneric;

namespace Betting.Profits
{
    public interface ITestMultiModel : IName
    {
        IEnumerable<ITestModel> Models { get; }

    }
}
