using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Betting.ViewModel
{
    class DataPointsFactory
    {

 
        public static IObservable<DataPoint[]> GenerateMultipleLast(int balance, int profitablity, int win, int sigma)
        {
            const int runs = 200;
            var observable = Task.Run(() =>
            {
                var curvepoints = Enumerable.Range(0, 100)
                .Select(fraction =>
                {
                    var profit = Enumerable.Range(0, runs)
                    .Select(a => Generate(balance, fraction, profitablity, win, sigma).Last()).Average(a => a.Y);
                    return new DataPoint(fraction, System.Math.Log10(profit));
                }).AsParallel().ToArray(); ;
                return curvepoints;
            }).ToObservable();

            return observable;
        }


        public static IObservable<DataPoint[][]> GenerateMultiple(int balance, int fraction, int profitablity, int win, int sigma, int run)
        {
            var observable = Task.Run(() =>
            {
                var points = Enumerable.Range(0, run)
                .Select(a => Generate(balance, fraction, profitablity, win, sigma))
                .SelectMany(a => a).AsParallel().ToArray();

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



        public static IEnumerable<DataPoint> Generate(int balance, int fraction, int profitablity, int win, int sigma)
        {
            int i;

            using var enumerator = new BalanceFactory(balance).GetValues(fraction / 100d, profitablity / 1000d, win / 100d, sigma / 100d).GetEnumerator();
            for (enumerator.MoveNext(), i = 0; i < 1000; enumerator.MoveNext())
            {
                yield return new DataPoint(i++, enumerator.Current);
            }
        }


    }
}

