﻿using System;

namespace Betting.Entity.Sqlite
{
    public interface ITransaction: UtilityInterface.NonGeneric.Database.IGuid
    {
        int Amount { get; set; }
        DateTime Date { get; set; }
    }
}