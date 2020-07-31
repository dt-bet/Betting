using SQLite;
using System;
using Betting.Abstract.DAL;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Strategy")]

    public class Strategy : DBEntity, IStrategy
    {
        public Strategy(Guid guid, string key, string description) : this(key, description, guid)
        {
        }

        public Strategy(string key, string description) : this(key, description, Guid.NewGuid())
        {
        }

        private Strategy(string key, string description, Guid guid) : base(guid)
        {
            Key = key;
            Description = description;
        }

        public Strategy() 
        {

        }

        [Unique]
        public string Key { get; set; }

        public string Description { get; set; }

    }
}
