//using Betting.Model;
//using Betting;
//using DynamicData;
//using NodaMoney;
//using Reactive.Bindings.Extensions;
//using ReactiveUI;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Linq;
//using System.Reactive.Concurrency;
//using System.Reactive.Linq;
//using System.Reactive.Subjects;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using UtilityHelper;
//using UtilityHelper.NonGeneric;
//using WPFExtension;

//namespace Betting.View
//{

//    public class ProfitTracker3 : Control
//    {
//        public static readonly DependencyProperty PricesProperty = DependencyProperty.Register("Prices", typeof(IEnumerable), typeof(ProfitTracker3), new PropertyMetadata(null, Changed));



//        public static readonly DependencyProperty PositionsProperty = DependencyProperty.Register("Positions", typeof(IEnumerable), typeof(ProfitTracker3), new PropertyMetadata(null, Changed));


//        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(ProfitTracker3), new PropertyMetadata("Date", Changed));

//        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(ProfitTracker3), new PropertyMetadata("Price", Changed));

//        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(string), typeof(ProfitTracker3), new PropertyMetadata("key", Changed));

//        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(string), typeof(ProfitTracker3), new PropertyMetadata("Position", Changed));

//        //public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(string), typeof(ProfitTracker3), new PropertyMetadata("Result", Changed));

//        //public static readonly DependencyProperty ProfitTrackerProperty = DependencyProperty.Register("ProfitTracker", typeof(ProfitTracker), typeof(ProfitTracker3), new PropertyMetadata(null));

//        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(double), typeof(ProfitTracker3), new PropertyMetadata(100d, Changed));


//        //public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(double), typeof(ProfitTracker3), new PropertyMetadata(100d, Changed));


//        public IEnumerable Prices
//        {
//            get { return (IEnumerable)GetValue(PricesProperty); }
//            set { SetValue(PricesProperty, value); }
//        }

//        public IEnumerable Positions
//        {
//            get { return (IEnumerable)GetValue(PositionsProperty); }
//            set { SetValue(PositionsProperty, value); }
//        }

//        public string Key
//        {
//            get { return (string)GetValue(KeyProperty); }
//            set { SetValue(KeyProperty, value); }
//        }


//        public string Date
//        {
//            get { return (string)GetValue(DateProperty); }
//            set { SetValue(DateProperty, value); }
//        }

//        public double Start
//        {
//            get { return (double)GetValue(StartProperty); }
//            set { SetValue(StartProperty, value); }
//        }

//        //public string Result
//        //{
//        //    get { return (String)GetValue(ResultProperty); }
//        //    set { SetValue(ResultProperty, value); }
//        //}

//        public string Position
//        {
//            get { return (string)GetValue(PositionProperty); }
//            set { SetValue(PositionProperty, value); }
//        }

//        public string Price
//        {
//            get { return (string)GetValue(PriceProperty); }
//            set { SetValue(PriceProperty, value); }
//        }

//        //public ProfitTracker ProfitTracker
//        //{
//        //    get { return (ProfitTracker)GetValue(ProfitTrackerProperty); }
//        //    set { SetValue(ProfitTrackerProperty, value); }
//        //}

//        Dictionary<string, Subject<object>> dict = typeof(ProfitTracker3).GetDependencyProperties().ToDictionary(_ => _.Name.Substring(0, _.Name.Length - 8), _ => new Subject<object>());
//        private ReadOnlyObservableCollection<Position> _data;
//        private ReadOnlyObservableCollection<Price> _data2;
//        //private ReadOnlyObservableCollection<IGroup<KeyValuePair<string, KeyValuePair<DateTime, double>>, string, string>> _data;







//        // Using a DependencyProperty as the backing store for Prices_.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty Prices_Property =
//            DependencyProperty.Register("Prices_", typeof(IEnumerable), typeof(ProfitTracker3), new PropertyMetadata(null));

//        // Using a DependencyProperty as the backing store for Prices_.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty Positions_Property =
//            DependencyProperty.Register("Positions_", typeof(IEnumerable), typeof(ProfitTracker3), new PropertyMetadata(null));



//        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            (d as ProfitTracker3).dict[e.Property.Name].OnNext(e.NewValue);
//        }


//        static ProfitTracker3()
//        {
//            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProfitTracker3), new FrameworkPropertyMetadata(typeof(ProfitTracker3)));
//        }



//        public ProfitTracker3()
//        {
//            this.SetValue(Prices_Property, _data2);
//            this.SetValue(Positions_Property, _data);
//            Dictionary<string, ObservableCollection<KeyValuePair<DateTime, double>>> x = new Dictionary<string, ObservableCollection<KeyValuePair<DateTime, double>>>();

//         var xx=   dict[nameof(Prices)].Where(_ => _ != null)
//     .CombineLatest(dict[nameof(Date)],
//     dict[nameof(Key)].Where(_ => _ != null),
//     dict[nameof(Price)].Where(_ => _ != null),
//     (prices, date, key, price) => new { prices, date, key, price })
//     .Select(_ => GetChanges((IEnumerable)_.prices, (string)_.date, (string)_.key, (string)_.price)).Switch()

//               .Select(_ => new Delta { Key = _.Key, DateTime =_.Value.Key, Movement = _.Value.Value })
//         .ToObservableChangeSet(_ => _.Key)
//                   .Group(_ => _.Key)
//                                  .Transform(_ => new Price(_))
//                      .Bind(out _data2)
//                .DisposeMany()
//                .Subscribe();


//            dict[nameof(Positions)].Where(_ => _ != null)
//                .CombineLatest(dict[nameof(Date)],
//                dict[nameof(Key)].Where(_ => _ != null),
//                dict[nameof(Position)].Where(_ => _ != null),
//                (positions, date, key, position) => new { positions, date, key, position })
//               .Select(_ => GetChanges((IEnumerable)_.positions, (string)_.date, (string)_.key, (string)_.position)).Switch()
              
//               .Select(_ => new Trade { Key = _.Key, Amount = (Money)_.Value.Value, Date = _.Value.Key })
//               .ToObservableChangeSet(_ => _.Key)
//               .Group(_ => _.Key)
//               .Transform(_ => new Position(_))
//               .Bind(out _data)
//                .DisposeMany()
//                .Subscribe();




 

//        }





//        private static IObservable<KeyValuePair<string, KeyValuePair<DateTime, double>>> GetChanges(IEnumerable data, string date, string key, string value)
//        {
//            Type type = null;
//            PropertyInfo Date_ = null;
//            PropertyInfo Key_ = null;
//            PropertyInfo Value = null;

//            return Observable.Create<KeyValuePair<string, KeyValuePair<DateTime, double>>>(observer => ((data as INotifyCollectionChanged)?.CollectionChangedAsObservable() ?? Observable.Empty<NotifyCollectionChangedEventArgs>())
//                         .StartWith(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, data)).Subscribe(_ =>
//                         {

//                             if (data.Count() > 0)
//                             {
//                                 if (type == null)
//                                 {
//                                     type = data.First().GetType();
//                                     Date_ = type.GetProperty(date);
//                                     Key_ = type.GetProperty(key);
//                                     Value = type.GetProperty(value);
     
//                                 }
//                                 foreach (var __ in _.NewItems)
//                                 {
//                                     observer.OnNext(new KeyValuePair<string, KeyValuePair<DateTime, double>>(__.GetPropValue<string>(Key_),
//                                         new KeyValuePair<DateTime, double>(__.GetPropValue<DateTime>(Date_), __.GetPropValue<double>(Value))));
//                                 }

//                             }

//                         }));
//        }



//        private static IObservable<KeyValuePair<string, KeyValuePair<DateTime, Tuple<double, double>>>> GetChanges(IEnumerable data, string date, string key, string value, string value2)
//        {
//            Type type = null;
//            PropertyInfo Date_ = null;
//            PropertyInfo Key_ = null;
//            PropertyInfo Value = null;
//            PropertyInfo Value2 = null;

//            return Observable.Create<KeyValuePair<string, KeyValuePair<DateTime, Tuple<double,double>>>>(observer => ((data as INotifyCollectionChanged)?.CollectionChangedAsObservable() ?? Observable.Empty<NotifyCollectionChangedEventArgs>())
//                         .StartWith(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, data)).Subscribe(_ =>
//                         {

//                             if (data.Count() > 0)
//                             {
//                                 if (type == null)
//                                 {
//                                     type = data.First().GetType();
//                                     Date_ = type.GetProperty(date);
//                                     Key_ = type.GetProperty(key);
//                                     Value = type.GetProperty(value);
//                                     Value2 = type.GetProperty(value2);
//                                 }
//                                 foreach (var __ in _.NewItems)
//                                 {
//                                     observer.OnNext(new KeyValuePair<string, KeyValuePair<DateTime,Tuple< double,double>>>(__.GetPropValue<string>(Key_),
//                                         new KeyValuePair<DateTime, Tuple<double,double>>(__.GetPropValue<DateTime>(Date_),Tuple.Create( __.GetPropValue<double>(Value), __.GetPropValue<double>(Value2)))));
//                                 }

//                             }

//                         }));
//        }


//    }



//    //public class TradesPosition
//    //{
//    //    private readonly int _count;

//    //    public TradesPosition(decimal buy, decimal sell, int count)
//    //    {
//    //        Buy = buy;
//    //        Sell = sell;
//    //        _count = count;
//    //        Position = Buy - Sell;
//    //    }

//    //    public bool Negative => Position < 0;


//    //    public decimal Position { get; }
//    //    public decimal Buy { get; }
//    //    public decimal Sell { get; }
//    //    public string CountText => "Order".Pluralise(_count);
//    //}
//}