using OxyPlot;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Betting.ViewModel
{
    public class ProfitChartViewModel : ReactiveObject
    {

        private readonly ReactiveCommand<object, int> balance;
        private readonly ReactiveCommand<object, int> fraction;
        private readonly ReactiveCommand<object, int> win;
        private readonly ReactiveCommand<object, int> sigma;
        private readonly ReactiveCommand<object, int> run;
        private readonly ReactiveCommand<object, bool> removePrevious;
        private readonly ObservableAsPropertyHelper<DataPoint[][]> dataPoints;
        Collection<DataPoint> points = new Collection<DataPoint>();

        private Task<DataPoint[][]> task;
        private CancellationToken token;
        CancellationTokenSource ct = new CancellationTokenSource();
        public ProfitChartViewModel()
        {
            balance = ReactiveCommand.Create<object, int>(a => System.Convert.ToInt32(a));
            fraction = ReactiveCommand.Create<object, int>(a => System.Convert.ToInt32(a));
            win = ReactiveCommand.Create<object, int>(a => System.Convert.ToInt32(a));
            sigma = ReactiveCommand.Create<object, int>(a => System.Convert.ToInt32(a));
            run = ReactiveCommand.Create<object, int>(a => System.Convert.ToInt32(a));
            removePrevious = ReactiveCommand.Create<object, bool>(a => Convert.ToBoolean(a));

            dataPoints = balance
                .StartWith(5).Where(a => a > -1).CombineLatest(
                fraction.StartWith(5).Where(a => a > -1),
                win.StartWith(5),
                sigma.StartWith(5).Where(a => a > -1),
                removePrevious.StartWith(true),
                run.StartWith(1), (a, b, c, d, e, f) => (a, b, c, d, e, f)
              )
                .Buffer(TimeSpan.FromSeconds(2))
                .Select(a => a.LastOrDefault())
                .Where(a => a.Equals(default)==false)
                .SelectMany(a => GenerateMultiple(a.a, a.b, a.c, a.d, a.e, a.f))
             .Select(a =>
             {
                 return a;
             })
             .ToProperty(this, a => a.DataPoints);

            dataPoints.ThrownExceptions.Subscribe(a =>
            {

            });
        }

        public IObservable<DataPoint[][]> GenerateMultiple(int balance, int fraction, int win, int sigma, bool removePrevious, int run)
        {


            var observable = Task.Run(() =>
            {

                if (removePrevious)
                    points = new Collection<DataPoint>();

                foreach (var point in Enumerable.Range(0, run).Select(a => Generate(balance, fraction, win, sigma, removePrevious)).SelectMany(a => a).AsParallel().ToArray())
                {
                    points.Add(point);
                }
                var xee = points.GroupBy(a => a.X).OrderBy(a => a.Key).Select(a =>
                  {

                      var arr = a.Select(v => v.Y).ToArray();
                      if (arr.Length > 1)
                      {
                          var msd = MathNet.Numerics.Statistics.Statistics.MeanStandardDeviation(arr);
                          return new[] { new DataPoint(a.Key, msd.Item1), new DataPoint(a.Key, msd.Item1 - msd.Item2), new DataPoint(a.Key, msd.Item1 + msd.Item2) };
                      }
                      var dp = arr.Single();
                      return new[] { new DataPoint(a.Key, dp), new DataPoint(a.Key, dp), new DataPoint(a.Key, dp) };
                  }).ToArray();

                return xee;

            }).ToObservable();


            return observable;
        }

        public IEnumerable<DataPoint> Generate(int balance, int fraction, int win, int sigma, bool removePrevious)
        {

            int i;

            using (var enumerator = new Class1(balance).GetValues(fraction / 100d, win / 100d, sigma / 100d).GetEnumerator())
                for (enumerator.MoveNext(), i = 0; i < 100; enumerator.MoveNext())
                {
                    points.Add(new DataPoint(i++, enumerator.Current));
                }

            return points;
        }



        public ICommand Balance => balance;

        public ICommand Fraction => fraction;

        public ICommand Win => win;

        public ICommand Sigma => sigma;

        public ICommand Run => run;

        public ICommand UsePrevious => removePrevious;

        public DataPoint[][] DataPoints => dataPoints.Value;





        public class Class1
        {
            private double balance;
            private readonly Random random;
            private readonly Troschuetz.Random.TRandom trandom;

            public Class1(double balance)
            {
                this.balance = balance;
                random = new Random();
                trandom = Troschuetz.Random.TRandom.New();
            }

            public IEnumerable<double> GetValues(double a, double b, double c)
            {
                while (true)
                {
                    balance = Next(balance, a, b, c);
                    yield return balance;
                }

                double Next(double balance, double percentage, double win, double sigma)
                {
                    var tRandom = trandom.Normal(win, sigma);
                    return balance + (percentage * balance) * tRandom;
                }

                //double Next(double balance, double percentage, double win, double sigma)
                //{
                //    var mRandom = Normal.Sample(random, win, sigma);
                //     return balance + (percentage * balance) * mRandom;
                //}
            }
        }
    }
}
