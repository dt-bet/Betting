using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    public class Strategy : DBEntity, IStrategy
    {
        [Unique]
        public string Key { get; set; }

        public string Description { get; set; }

    }
}
