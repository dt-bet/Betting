

using Betting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UtilityHelper;

using Reactive.Bindings.Extensions;
using System.Reactive.Subjects;
using DynamicData;
using Reactive.Bindings;
using System.Collections.Specialized;

namespace Betting.View
{
    //public class Combined
    //{

    //    public IConvertible Key { get; set; }
    //    public double Initial { get; set; }
    //    public SortedList<DateTime, double> Changes { get; set; }
    //}

    //public struct Change
    //{
    //    public DateTime Date { get; set; }
    //    public IConvertible Key { get; set; }
    //    public double Amount { get; set; }
    //}


    ////public struct PositionChange
    ////{
    ////    public DateTime Date { get; set; }
    ////    public IConvertible Key { get; set; }
    ////    public double Amount { get; set; }
    ////}

    ////public struct Position
    ////{
    ////    public IConvertible Key { get; set; }

    ////    //public double Bought { get; set; }
    ////    //public double Sold { get; set; }
    ////    //public double Sum { get{return Bought-Sold; }
    ////}

    ////public struct Profit
    ////{
    ////    public DateTime Date { get; set; }
    ////    public IConvertible Key { get; set; }
    ////    public double Amount { get; set; }
    ////}

    //public class Asset
    //{
    //    public IConvertible Key { get; set; }
    //    public SortedList<DateTime, double> Prices { get; set; }
    //    public SortedList<DateTime, double> Positions { get; set; }
    //    public SortedList<DateTime, double> Profits { get; set; }

    //}

    //public class CurrentAsset
    //{
    //    public IConvertible Key { get; set; }
    //    public DateTime Date { get; set; }
    //    public double Price { get; set; }
    //    public double Position { get; set; }
    //    public double Profit { get; set; }

    //}


    //public class ProfitTrackWrapper2 : Control
    //{
    //    public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Date"));

    //    public static readonly DependencyProperty KeyProperty = DependencyHelper.Register();

    //    public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Price"));

    //    public static readonly DependencyProperty PositionProperty = DependencyHelper.Register();

    //    //public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Prediction"));

    //    //public static readonly DependencyProperty ProfitTrackerProperty = DependencyProperty.Register("ProfitTracker", typeof(ProfitTracker), typeof(ProfitTrackWrapper), new PropertyMetadata(null));

    //    public static readonly DependencyProperty NewAssetProperty = DependencyHelper.Register();



    //    public static readonly DependencyProperty ProfitsProperty = DependencyHelper.Register();



    //    public static readonly DependencyProperty PositionsProperty = DependencyHelper.Register();

    //    public static readonly DependencyProperty PricesProperty = DependencyHelper.Register();

    //    INotifyCollectionChanged DataAsObservableCollection;
    //    private static void DataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        if (!e.GetType().GetInterfaces().Contains(typeof(INotifyCollectionChanged)))
    //            (d as ProfitTrackWrapper).DataAsObservableCollection = new ObservableCollection<object>((e.NewValue as IEnumerable).Cast<object>());
    //        else
    //            (d as ProfitTrackWrapper).DataAsObservableCollection = e.NewValue as INotifyCollectionChanged;
    //        (e.NewValue as INotifyCollectionChanged).CollectionChangedAsObservable().Subscribe(_ =>
    //        {

    //        });
    //        (e.NewValue as INotifyCollectionChanged).CollectionChanged += ProfitTrackWrapper_CollectionChanged;
    //        (d as ProfitTrackWrapper).dict[e.Property.Name].OnNext(e.NewValue as INotifyCollectionChanged);
    //    }


    //    public static readonly DependencyProperty AssetsProperty = DependencyHelper.Register();

    //    public static readonly DependencyProperty CurrentAssetsProperty = DependencyHelper.Register();

    //    public static readonly DependencyProperty ProfitChangesProperty = DependencyHelper.Register();

    //    public static readonly DependencyProperty PriceChangesProperty = DependencyHelper.Register();

    //    public static readonly DependencyProperty PositionChangesProperty = DependencyHelper.Register();

    //    public ObservableCollection<Asset> Assets
    //    {
    //        get { return (ObservableCollection<Asset>)GetValue(AssetsProperty); }
    //        set { SetValue(AssetsProperty, value); }
    //    }

    //    public ObservableCollection<CurrentAsset> CurrentAssets
    //    {
    //        get { return (ObservableCollection<CurrentAsset>)GetValue(CurrentAssetsProperty); }
    //        set { SetValue(CurrentAssetsProperty, value); }
    //    }


    //    public KeyValuePair<string, ObservableCollection<object>> NewAsset
    //    {
    //        get { return (KeyValuePair<string, ObservableCollection<object>>)GetValue(NewAssetProperty); }
    //        set { SetValue(NewAssetProperty, value); }
    //    }

    //    public ObservableCollection<object> PositionChanges
    //    {
    //        get { return (ObservableCollection<object>)GetValue(PositionChangesProperty); }
    //        set { SetValue(PositionChangesProperty, value); }
    //    }

    //    public ObservableCollection<object> PriceChanges
    //    {
    //        get { return (ObservableCollection<object>)GetValue(PriceChangesProperty); }
    //        set { SetValue(PriceChangesProperty, value); }
    //    }

    //    public ReadOnlyObservableCollection<Change> ProfitChanges
    //    {
    //        get { return (ReadOnlyObservableCollection<Change>)GetValue(ProfitChangesProperty); }
    //        set { SetValue(ProfitChangesProperty, value); }
    //    }

    //    public ReadOnlyObservableCollection<Combined> Positions
    //    {
    //        get { return (ReadOnlyObservableCollection<Combined>)GetValue(PositionsProperty); }
    //        set { SetValue(PositionsProperty, value); }
    //    }

    //    public ReadOnlyObservableCollection<Combined> Prices
    //    {
    //        get { return (ReadOnlyObservableCollection<Combined>)GetValue(PricesProperty); }
    //        set { SetValue(PricesProperty, value); }
    //    }

    //    public ReadOnlyObservableCollection<Combined> Profits
    //    {
    //        get { return (ReadOnlyObservableCollection<Combined>)GetValue(ProfitsProperty); }
    //        set { SetValue(ProfitsProperty, value); }
    //    }

    //    public string Key
    //    {
    //        get { return (string)GetValue(KeyProperty); }
    //        set { SetValue(KeyProperty, value); }
    //    }

    //    public string Position
    //    {
    //        get { return (string)GetValue(PositionProperty); }
    //        set { SetValue(PositionProperty, value); }
    //    }

    //    public string Date
    //    {
    //        get { return (string)GetValue(DateProperty); }
    //        set { SetValue(DateProperty, value); }
    //    }


    //    public string Price
    //    {
    //        get { return (string)GetValue(PriceProperty); }
    //        set { SetValue(PriceProperty, value); }
    //    }


    //    static ProfitTrackWrapper2()
    //    {
    //        DefaultStyleKeyProperty.OverrideMetadata(typeof(ProfitTrackWrapper), new FrameworkPropertyMetadata(typeof(ProfitTrackWrapper)));
    //    }

    //    ISubject<Change> pricesubject = new Subject<Change>();
    //    ISubject<Change> profitsubject = new Subject<Change>();
    //    ISubject<Change> positionsubject = new Subject<Change>();

    //    ISubject<Combined> pricecombinedsubject = new Subject<Combined>();
    //    ISubject<Combined> profitcombinedsubject = new Subject<Combined>();
    //    ISubject<Combined> positioncombinedsubject = new Subject<Combined>();

    //    ISubject<CurrentAsset> currentassetssubject = new Subject<CurrentAsset>();
    //    ISubject<Asset> assetssubject = new Subject<Asset>();

    //    public ProfitTrackWrapper2()
    //    {
    //        var obs = Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => this.Loaded += h, h => this.Loaded -= h).Select(_ => 0);/*.Subscribe(_=>*/
    //        //GetProfitTrack());

    //        var x = this.ToReadOnlyReactiveProperty<KeyValuePair<string, ObservableCollection<object>>>(NewAssetProperty);
    //        x.Subscribe(_ =>
    //        {
    //            _.Value.ObserveAddChanged()
    //            .CombineLatest(this.ToReadOnlyReactiveProperty<string>(DateProperty), (item, date) => new { item, date })
    //            //.CombineLatest(this.ToReadOnlyReactiveProperty<string>(PriceProperty), (a, b) => new { a, b })
    //            .CombineLatest(this.ToReadOnlyReactiveProperty<string>(PriceProperty), (a, price) => new { a, price })
    //            .Subscribe(__ =>
    //            {
    //                var item = __.a.item;
    //                pricesubject.OnNext(new Change { Date = item.GetPropValue<DateTime>(__.a.date), Key = _.Key, Amount = item.GetPropValue<double>(__.price) });
    //            });
    //        });

    //        var yt = this.ToReadOnlyReactiveProperty<ObservableCollection<object>>(PositionsProperty)
    //            .CombineLatest(this.ToReadOnlyReactiveProperty<string>(DateProperty), (item, date) => new { item, date })
    //            .CombineLatest(this.ToReadOnlyReactiveProperty<string>(KeyProperty), (a, key) => new { a, key })
    //            .CombineLatest(this.ToReadOnlyReactiveProperty<string>(PositionProperty), (a, position) => new { a, position })
    //            .Subscribe(ab =>
    //        {
    //            /*subject.CombineLatest(*/
    //            ab.a.a.item.ObserveAddChanged().Subscribe(item =>
    //            {
    //                positionsubject.OnNext(new Change { Date = item.GetPropValue<DateTime>(ab.a.a.date), Key = item.GetPropValue<IConvertible>(ab.a.key), Amount = item.GetPropValue<double>(ab.position) });
    //            });
    //            //.GroupBy(_x => _x.Key)
    //            //.Select(_c =>
    //            //{
    //            //   return  _c.Scan(new SortedList<DateTime,double>(),(a,b)=> {a.Add(b.Date,b.Amount);return a; })
    //            //    .Subscribe(c_ =>
    //            //    {

    //            //        positionsubject.OnNext(new Combined {Changes=c_,Initial=0,Key=_c.Key });
    //            //        //profitsubject.OnNext(new Profit { Date = _a.Date, Key = _a.Key, Profit = *_a.Price });
    //            //    });
    //            //});

    //        });

    //        ReactiveCollection<Asset> assets = new ReactiveCollection<Asset>();
    //        ReactiveCollection<Combined> profits = new ReactiveCollection<Combined>();
    //        ReactiveCollection<Combined> positions = new ReactiveCollection<Combined>();
    //        ReactiveCollection<Combined> prices = new ReactiveCollection<Combined>();

    //        var jxx = pricesubject.ToObservableChangeSet(_ => _.Key);
    //        jxx.Bind(out priceCollection).DisposeMany();
    //        var xx1 = profitsubject.ToObservableChangeSet(_ => _.Key);
    //        xx1.Bind(out profitCollection).DisposeMany();
    //        var xx2 = positionsubject.ToObservableChangeSet(_ => _.Key);
    //        xx2.Bind(out positionCollection).DisposeMany();


    //        positionsubject.Subscribe(_ =>
    //        {
    //            var xx = prices.SingleOrDefault(c => c.Key == _.Key);
    //            var profit = new Change { Key = _.Key, Date = _.Date, Amount = _.Amount * positions.Single(c => c.Key == xx.Key).Changes.Sum(ch => ch.Value) };
    //            profitsubject.OnNext(profit);
    //            fsd2(ref assets,ref profits,ref prices, _.Key, profit, _);

    //        });



    //        pricesubject.Subscribe(_ =>
    //        {
    //            var xx = positions.SingleOrDefault(c => c.Key == _.Key);
    //            var profit = new Change { Key = _.Key, Date = _.Date, Amount = xx.Changes.Sum(ch => ch.Value) * _.Amount };
    //            profitsubject.OnNext(profit);

    //            fsd(ref assets, ref profits, ref positions, _.Key, profit, _);

    //        });


    //    }




    //    private void fsd(ref ReactiveCollection<Asset> assets, ref ReactiveCollection<Combined> profits, ref ReactiveCollection<Combined> positions, IConvertible key, Change profit,Change position )
    //    {

    //        var s = assets.SingleOrDefault(_ => _.Key == key);
    //        if (s == null)
    //        {
    //            var positions2 = new SortedList<DateTime, double>(new Dictionary<DateTime, double>() { { position.Date, position.Amount } });
    //            var profits2 = new SortedList<DateTime, double>(new Dictionary<DateTime, double>() { { profit.Date, profit.Amount } });
    //            assets.Add(new Asset
    //            {
    //                Key = key,
    //                Positions= positions2,
    //                Prices = new SortedList<DateTime, double>(new Dictionary<DateTime, double>()),
    //                Profits = profits2,
    //            });
    //            positions.Add(new Combined { Changes = positions2, Key = key });
    //            profits.Add(new Combined { Changes = profits2, Key = key });
    //        }
    //        else
    //        {
    //            s.Profits.Add(profit.Date, profit.Amount);
    //            s.Positions.Add(position.Date, position.Amount);
    //        }
    //    }

    //    private void fsd2(ref ReactiveCollection<Asset> assets, ref ReactiveCollection<Combined> profits, ref ReactiveCollection<Combined> prices, IConvertible key, Change profit, Change price)
    //    {

    //        var s = assets.SingleOrDefault(_ => _.Key == key);
    //        if (s == null)
    //        {
              
    //            var prices2 = new SortedList<DateTime, double>(new Dictionary<DateTime, double>() { { price.Date, price.Amount } });
    //            var profits2 = new SortedList<DateTime, double>(new Dictionary<DateTime, double>() { { profit.Date, profit.Amount } });
    //            assets.Add(new Asset
    //            {
    //                Key = key,
    //                Positions = new SortedList<DateTime, double>(new Dictionary<DateTime, double>()),
    //                Prices = prices2,
    //                Profits =profits2
    //            });
    //            profits.Add(new Combined { Changes = profits2, Key = key });
    //            prices.Add(new Combined { Changes = prices2, Key = key });
    //        }
    //        else
    //        {
    //            s.Profits.Add(profit.Date, profit.Amount);
    //            s.Prices.Add(price.Date, price.Amount);
    //        }
    //    }


    //    readonly ReadOnlyObservableCollection<CurrentAsset> currentassetsCollection;

    //    readonly ReadOnlyObservableCollection<Asset> assetsCollection;

    //    readonly ReadOnlyObservableCollection<Change> priceCollection;
    //    //public ReadOnlyObservableCollection<Price> PriceCollection => priceCollection;

    //    readonly ReadOnlyObservableCollection<Change> profitCollection;
    //    //public ReadOnlyObservableCollection<Profit> ProfitCollection => profitCollection;

    //    readonly ReadOnlyObservableCollection<Change> positionCollection;

    //    readonly ReadOnlyObservableCollection<Combined> priceAllCollection;
    //    //public ReadOnlyObservableCollection<Price> PriceCollection => priceCollection;

    //    readonly ReadOnlyObservableCollection<Combined> profitAllCollection;
    //    //public ReadOnlyObservableCollection<Profit> ProfitCollection => profitCollection;

    //    readonly ReadOnlyObservableCollection<Combined> positionAllCollection;



    //    //public ReadOnlyObservableCollection<Position> PositionCollection => positionCollection;
    //    //private static void fsdf(object item)
    //    //{
    //    //    var xx = new PositionChange { Date = item.GetPropValue<DateTime>(), Key = item.GetPropValue<DateTime>(), Amount = item.GetPropValue<double>() };

    //    //        .GroupBy(_x => _x.Key)
    //    //        .Select(_c =>
    //    //        {
    //    //            _c.Sum(v => v.Amount).Subscribe(cv =>
    //    //            {
    //    //                return new Position { Key = _c.Key, Amount = cv, Date = item.Date };
    //    //            });
    //    //        });
    //    //}

    //    //ObservableCollection

    //    //public  void GetProfitTrack()
    //    //{

    //    //    var Date_ = Data.GetPropValues<DateTime>(Date).ToArray();
    //    //    var Result_ = Data.GetPropValues<bool>(Result).ToArray();
    //    //    var Prediction_ = Data.GetPropValues<double>(Prediction).ToArray();
    //    //    var Price_ = Data.GetPropValues<double>(Price).ToArray();


    //    //    var profitTracker = new Betting.ProfitTracker(10000, Date_[0], UtilityEnum.Betting.Side.Back,"home");


    //    //    //var xx = TrialMatches.Zip(predictions, (a, b) => { if (b > 0) { return a.GetUnitProfitHome() * b; } else return 0; });

    //    //    //var yy = xx.Average();

    //    //    for (int i = 0; i < Data.Count(); i++)
    //    //    {
    //    //        try
    //    //        {
    //    //            var week = Date_[i].GetWeekOfYear();
    //    //            profitTracker.UpdateWeek(week);

    //    //            //var probs = ProbabilityMaths.FromGaussian(predictions[i], 1).Reverse().ToArray();

    //    //            profitTracker.MakeBet(Date_[i], Prediction_[i], (decimal)Price_[i], UtilityEnum.Betting.Side.Back);

    //    //            profitTracker.ExecuteBet(Date_[i], ContractType.Home);

    //    //        }
    //    //        catch (Exception e)
    //    //        {
    //    //            Console.WriteLine(e.Message + "unable to update profit controller");

    //    //        }
    //    //    }

    //    //    ProfitTracker = profitTracker;
    //    //}


    //}
}
