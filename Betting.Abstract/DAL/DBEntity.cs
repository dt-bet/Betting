using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityInterface.NonGeneric.Database;

namespace Betting.Abstract.DAL
{
    public abstract class DBEntity : IId, IGuid, IEquatable<DBEntity>
    {
        [PrimaryKey]
        public long Id { get; set; }

        [Indexed, Unique]
        public Guid Guid { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DBEntity);
        }

        public bool Equals(DBEntity other)
        {
            return other != null &&
                   Guid.Equals(other.Guid);
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
