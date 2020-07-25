using Betting.Abstract.DAL;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Entity.Sqlite
{
    public class Transaction : DBEntity, ITransaction
    {

        public DateTime Date { get; set; }

        public int Amount { get; set; }

    }
}
