using Betting.Model;
using DynamicData;
using NodaMoney;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Betting.Enum;

namespace Betting.View
{
    public class Position : DynamicData.Binding.AbstractNotifyPropertyChanged, IDisposable, IEquatable<Position>
    {

        private readonly IDisposable _cleanUp;
        //private Position _position;

        private Money total;
        private Money bought;
        private Money sold;



        public Position(IGroup<Trade, string> trades)
        {
            Key = trades.GroupKey;

            _cleanUp = trades.List.Connect()
                .ToCollection()
                .Select(query =>
                {
                    var buy = query.Where(trade => trade.Amount.ToTransactionSide() == TransactionSide.Buy).Sum(trade => (decimal)trade.Amount);
                    var sell = query.Where(trade => trade.Amount.ToTransactionSide() == TransactionSide.Sell).Sum(trade => (decimal)trade.Amount);

                    var count = query.Count;
                    return new { buy, sell, count };
                })
                .Subscribe(position => { Bought = position.buy; Sold = position.sell; Total = position.buy + position.sell; }) ;
        }

        public string Key { get; }
        public Money Total { get => total; set => SetAndRaise(ref total, value); }
        public Money Bought { get => bought; set => SetAndRaise(ref bought, value); }
        public Money Sold { get => sold; set => SetAndRaise(ref sold, value); }




        #region Equality Members

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Key, other.Key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            return (Key != null ? Key.GetHashCode() : 0);
        }

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }

        #endregion

        public void Dispose()
        {
            _cleanUp.Dispose();
        }
    }
}

