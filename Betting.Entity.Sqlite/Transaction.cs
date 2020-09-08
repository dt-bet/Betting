using Betting.Abstract.DAL;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Entity.Sqlite
{
    [Dapper.Contrib.Extensions.Table("Transaction")]
    public class Transaction : DBEntity, ITransaction
    {
        public Transaction(DateTime date, int amount) : this(date, amount, Guid.NewGuid())
        {
            Date = date;
            Amount = amount;
        }

        public Transaction(Guid guid, DateTime date, int amount) : this(date, amount, guid)
        {
            Date = date;
            Amount = amount;
        }

        public Transaction(DateTime date, int amount, Guid guid) : base(guid)
        {
            Date = date;
            Amount = amount;
        }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

    }
}
