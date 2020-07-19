using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Betting.DAL
{
    public interface IConnection
    {

        public string ConnectionPath { get; }

        public int Insert<T>(IEnumerable<T> items)
        {
            var conn = DatabaseConnection;
            int insert = conn.InsertAll(items);
            return insert;
        }

        public int InsertOnlyNew<T>(IEnumerable<T> items) where T : new()
        {
            var arr = items;
            var conn = DatabaseConnection;
            var freshItems = items.Except(from item in items
                                          join existingItem in conn.Table<T>().ToArray()
         on item.GetHashCode() equals existingItem.GetHashCode()
                                          select item);

            int insert = conn.InsertAll(freshItems);
            return insert;
        }

        public SQLite.SQLiteConnection DatabaseConnection=> new SQLite.SQLiteConnection(ConnectionPath);
    }
}
