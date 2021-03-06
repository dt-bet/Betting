﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityInterface.NonGeneric.Database;

namespace Betting.Entity.Sqlite
{
    public class DBEntity : IDbEntity
    {
        public DBEntity()
        {
        }

        public DBEntity(Guid guid)
        {
            Guid = guid;
        }

        public DBEntity(long id, Guid guid) : this(guid)
        {
            Id = id;
        }

        [PrimaryKey]
        public long Id { get; set; }

        [Unique]
        public Guid Guid { get; set; }

        public DateTime AddedTime { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DBEntity);
        }

        public bool Equals(IDbEntity other)
        {
            return other != null &&
                   Guid.Equals((other as IGuid).Guid);
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Guid);
        }

        public static bool operator ==(DBEntity left, DBEntity right)
        {
            return EqualityComparer<DBEntity>.Default.Equals(left, right);
        }

        public static bool operator !=(DBEntity left, DBEntity right)
        {
            return !(left == right);
        }
    }
}
