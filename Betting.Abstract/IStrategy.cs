using System;

namespace Betting.Entity.Sqlite
{
    public interface IStrategy: UtilityInterface.NonGeneric.Database.IGuid
    {
        string Description { get; set; }
        string Key { get; set; }
    }
}