//using Betting.Model;
//using DynamicData;
//using NodaMoney;
//using System;
//using System.ComponentModel;
//using System.Linq;
//using System.Reactive.Linq;

//namespace Betting.View
//{
//    internal class Price : DynamicData.Binding.AbstractNotifyPropertyChanged, IDisposable, IEquatable<Price>
//    {

//        private readonly IDisposable _cleanUp;
//        //private Position _position;


//        public Money Final { get; set; }
//        public DateTime LastUpdated { get; set; }

//        public Price(IGroup<Delta, string, string> trades)
//        {
//            Key = trades.Key;

//            _cleanUp = trades.Cache.Connect()
//                .ToCollection()
//                .Select(query =>
//                new { final =
//                    query.Sum(_ => _.Movement),
//                    date = query.Last().DateTime }
//               )
//                .Subscribe(position =>{ Final = (Money)position.final; LastUpdated = position.date; });
//        }

//        public string Key { get; }


//        #region Equality Members

//        public bool Equals(Price other)
//        {
//            if (ReferenceEquals(null, other)) return false;
//            if (ReferenceEquals(this, other)) return true;
//            return string.Equals(Key, other.Key);
//        }

//        public override bool Equals(object obj)
//        {
//            if (ReferenceEquals(null, obj)) return false;
//            if (ReferenceEquals(this, obj)) return true;
//            if (obj.GetType() != this.GetType()) return false;
//            return Equals((Price)obj);
//        }

//        public override int GetHashCode()
//        {
//            return (Key != null ? Key.GetHashCode() : 0);
//        }

//        public static bool operator ==(Price left, Price right)
//        {
//            return Equals(left, right);
//        }

//        public static bool operator !=(Price left, Price right)
//        {
//            return !Equals(left, right);
//        }

//        #endregion

//        public void Dispose()
//        {
//            _cleanUp.Dispose();
//        }
//    }
//}

