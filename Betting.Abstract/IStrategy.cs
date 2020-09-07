using System;
using UtilityInterface.NonGeneric;

namespace Betting.Entity.Sqlite
{
    public interface IStrategy: UtilityInterface.NonGeneric.Database.IGuid, IName
    {
        string Description { get; }
    }
}