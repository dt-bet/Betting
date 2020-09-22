using SQLite;
using System;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Strategy")]

    public class Strategy : DBEntity, IStrategy
    {
        public Strategy(Guid guid, string name, string description) : this(name, description, guid)
        {
        }

        public Strategy(string name, string description) : this(name, description, Guid.NewGuid())
        {
        }

        private Strategy(string name, string description, Guid guid) : base(guid)
        {
            Name = name;
            Description = description;
        }

        public Strategy() 
        {

        }

        [Unique]
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
