using OxyPlot;
using ReactiveUI;
using DynamicData;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;

namespace Betting.ViewModel
{
    public class ProfitChartViewModel : ReactiveObject
    {
        const int fractionStartValue = 5;

        private readonly ReactiveCommand<object, int> balance;
        private readonly ReactiveCommand<object, int> fraction;
        private readonly ReactiveCommand<object, int> win;
        private readonly ReactiveCommand<object, int> sigma;
        private readonly ReactiveCommand<object, int> profitablity;
        private readonly ReactiveCommand<object, int> run;
        private readonly ReactiveCommand<object, object> runMany;
        private readonly ReactiveCommand<object, bool> removePrevious;
        private readonly ObservableAsPropertyHelper<DataPoint[][]> dataPoints;
        private readonly ObservableAsPropertyHelper<DataPoint[]> curveDataPoints;
        private readonly ReadOnlyObservableCollection<DataPoint> middlePoints;
        Collection<DataPoint> curvepoints = new Collection<DataPoint>();

        //private Task<DataPoint[][]> task;
        //private CancellationToken token;
        //CancellationTokenSource ct = new CancellationTokenSource();

        public ProfitChartViewModel()
        {
            balance = ReactiveCommand.Create<object, int>(a => Convert.ToInt32(a));
            fraction = ReactiveCommand.Create<object, int>(a => Convert.ToInt32(a));
            win = ReactiveCommand.Create<object, int>(a => Convert.ToInt32(a));
            sigma = ReactiveCommand.Create<object, int>(a => Convert.ToInt32(a));
            profitablity = ReactiveCommand.Create<object, int>(a => Convert.ToInt32(a));
            run = ReactiveCommand.Create<object, int>(a => Convert.ToInt32(a));
            runMany = ReactiveCommand.Create<object, object>(a => a);
            removePrevious = ReactiveCommand.Create<object, bool>(a => Convert.ToBoolean(a));

            var refCount = balance
                .StartWith(1).Where(a => a > -1).CombineLatest(
                fraction.StartWith(5).Where(a => a > -1),
                win.StartWith(5),
                sigma.StartWith(25).Where(a => a > -1),
                removePrevious.StartWith(true),
                run.StartWith(5),
                  profitablity.StartWith(5).Where(a => a > -1),
                (a, b, c, d, e, f, g) => (a, b, c, d, e, f, g))
                .Buffer(TimeSpan.FromSeconds(2))
                .Select(a => a.LastOrDefault())
                .Where(a => a.Equals(default) == false)
                .SelectMany(a =>
                {
                    if (a.e)
                        curvepoints.Clear();
                    return DataPointsFactory.GenerateMultiple(a.a, a.b, a.g, a.c, a.d, a.f);
                })
                .Select(ArrayHelper.Rearrange)
                .Publish()
                .RefCount();



            var refCount2 = balance
                .StartWith(1).Where(a => a > -1).CombineLatest(
                fraction.StartWith(5).Where(a => a > -1),
                win.StartWith(5),
                sigma.StartWith(25).Where(a => a > -1),

                removePrevious.StartWith(true),
                runMany,
                 profitablity.StartWith(5).Where(a => a > -1),
                (a, b, c, d, e, f, g) => (a, b, c, d, e, f, g))
                .Buffer(TimeSpan.FromSeconds(2))
                .Select(a => a.LastOrDefault())
                .Where(a => a.Equals(default) == false)
                .SelectMany(a =>
                {
                    if (a.e)
                        this.curvepoints.Clear();
                    return DataPointsFactory.GenerateMultipleLast(a.a, a.g, a.c, a.d);
                })
                .Publish()
                .RefCount();

            refCount.WithLatestFrom(fraction.StartWith(fractionStartValue), (a, b) => (a, b))
                .Select(c =>
                 {
                     var y = c.a[0].Last().Y;
                     return new DataPoint(c.b, y); ;
                 })
                .ToObservableChangeSet()
                .Bind(out middlePoints)
                .Subscribe();

            dataPoints = refCount.Select(a =>
             {
                 return a;
             })
             .ToProperty(this, a => a.DataPoints);

            curveDataPoints = refCount2.Select(a =>
            {
                return a;
            }).ToProperty(this, a => a.CurveDataPoints);

            dataPoints.ThrownExceptions.Subscribe(a =>
            {

            });
        }


        public ICommand Balance => balance;

        public ICommand Fraction => fraction;

        public ICommand Win => win;

        public ICommand Sigma => sigma;

        public ICommand Profitablity => profitablity;

        public ICommand Run => run;

        public ICommand RunMany => runMany;

        public ICommand UsePrevious => removePrevious;

        public DataPoint[][] DataPoints => dataPoints.Value;

        public DataPoint[] CurveDataPoints => curveDataPoints.Value;

        public ReadOnlyObservableCollection<DataPoint> MiddlePoints => middlePoints;
    }
}
