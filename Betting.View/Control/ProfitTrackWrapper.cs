

using Betting;
using Reactive.Bindings.Extensions;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
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
using UtilityHelper.NonGeneric;

namespace Betting.View
{

    public class ProfitTrackWrapper : Control
    {
        private ProfitTrack profitTrack;
        private Dictionary<string, Subject<object>> dict = typeof(ProfitTrackWrapper).GetDependencyProperties().ToDictionary(_ => _.Name.Substring(0, _.Name.Length - 8), _ => new Subject<object>());


        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ProfitTrackWrapper).dict[e.Property.Name].OnNext(e.NewValue);
        }


        public override void OnApplyTemplate()
        {
            profitTrack = this.GetTemplateChild("ProfitTrack") as Betting.View.ProfitTrack;
            ProfitTrackChanges.OnNext(profitTrack);
        }

        ISubject<ProfitTrack> ProfitTrackChanges = new Subject<ProfitTrack>();

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(IEnumerable), typeof(ProfitTrackWrapper), new PropertyMetadata(null, Changed));

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Date", Changed));

        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Price", Changed));

        public static readonly DependencyProperty PredictionProperty = DependencyProperty.Register("Prediction", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Prediction", Changed));

        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(string), typeof(ProfitTrackWrapper), new PropertyMetadata("Result", Changed));

        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(double), typeof(ProfitTrackWrapper), new PropertyMetadata(100d, Changed));


        public IEnumerable Data
        {
            get { return (IEnumerable)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public string Date
        {
            get { return (string)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public double Start
        {
            get { return (double)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        public string Result
        {
            get { return (String)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public string Prediction
        {
            get { return (string)GetValue(PredictionProperty); }
            set { SetValue(PredictionProperty, value); }
        }

        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }


        static ProfitTrackWrapper()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProfitTrackWrapper), new FrameworkPropertyMetadata(typeof(ProfitTrackWrapper)));
        }


        public ProfitTrackWrapper()
        {

            dict[nameof(Data)]
        .CombineLatest(
                  dict[nameof(Date)].StartWith(nameof(Date)),
        dict[nameof(Prediction)].StartWith(nameof(Prediction)),
      dict[nameof(Result)].StartWith(nameof(Result)),
   dict[nameof(Price)].StartWith(nameof(Price)),
     dict[nameof(Start)].StartWith(100d),
  ProfitTrackChanges,
   (data, date, prediction, result, price, start,profitTrack) => new { data, date, result, prediction, price, start,profitTrack })
        .Subscribe(_ =>
       {

           var d = GetProfitTrack((IEnumerable)_.data, (string)_.date, (string)_.result, (string)_.prediction, (string)_.price, (double)_.start)
            .Subscribe(_d =>
          this.Dispatcher.InvokeAsync(() => ((ProfitTrack)_.profitTrack).ProfitTracker = _d,
          System.Windows.Threading.DispatcherPriority.Background));
       });

        }



        private static IObservable<ProfitTracker> GetProfitTrack(IEnumerable data, string date, string result, string prediction, string price, double start)
        {
            Type type = null;
            PropertyInfo Date_ = null;
            PropertyInfo Result_ = null;
            PropertyInfo Prediction_ = null;
            PropertyInfo Price_ = null;
 
            var ptw = new ProfitTrackerWrapper();

            ProfitTracker profitTracker = null;

            return ((data as INotifyCollectionChanged)?.CollectionChangedAsObservable() ?? Observable.Empty<NotifyCollectionChangedEventArgs>())
                .StartWith(data.Cast<object>()
                .Select(_=>new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, _ )))
                .SubscribeOn(Scheduler.Default)
                .Select(_ =>
            {
           
                if (data.Count() > 0)
                {
                    if (type == null)
                    {
                        profitTracker = null;
                        type = data.First().GetType();
                        Date_ = type.GetProperty(date);
                        Result_ = type.GetProperty(result);
                        Prediction_ = type.GetProperty(prediction);
                        Price_ = type.GetProperty(price);
                    }
                    foreach (var __ in _.NewItems)
                    {
                        //foreach (var __ in item as IEnumerable)
                        //{
                            var _date = (DateTime)Date_.GetValue(__);
                            var _result = (bool)Result_.GetValue(__);
                            var _prediction = (double)Prediction_.GetValue(__);
                            var _price = (double)Price_.GetValue(__);

                            ptw.UpdateProfitTrack(profitTracker, Date: _date,Result: _result,Prediction: _prediction,Price: _price, start: start);
                       // }
                    }
                    return profitTracker;
                }
                return null;
            }).Where(_ => _ != null);

        }
    }
}
