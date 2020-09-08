using System;
using System.Collections.Generic;
using System.Text;
using UtilityInterface.NonGeneric;

namespace Betting.Abstract.Model
{
    public interface IMultiModel : IName
    {
        IEnumerable<IModel> Models { get; }
    }
}
