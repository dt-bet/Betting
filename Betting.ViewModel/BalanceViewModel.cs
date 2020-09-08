using DynamicData;
using OxyPlot;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Betting.ViewModel
{
    public class BalanceViewModel : ReactiveObject
    {

        private readonly ReactiveCommand<int, int> balance;
        private readonly ReactiveCommand<int, int> fraction;
        private readonly ReactiveCommand<int, int> win;
        private readonly ReactiveCommand<int, int> sigma;
        private readonly ObservableAsPropertyHelper<ICollection<DataPoint>> dataPoints;

        public BalanceViewModel()
        {
            balance = ReactiveCommand.Create<int, int>(a => a);
            fraction = ReactiveCommand.Create<int, int>(a => a);
            win = ReactiveCommand.Create<int, int>(a => a);
            sigma = ReactiveCommand.Create<int, int>(a => a);

            dataPoints = balance.StartWith(1).Where(a => a > 0)
                .CombineLatest(
                fraction.StartWith(1).Where(a=>a>0),
                win.StartWith(1).Where(a => a > 0),
                sigma.StartWith(1).Where(a => a > 0),
              (a, b, c, d) =>
              Generate(a, b, c, d))
             .ToProperty(this, a => a.DataPoints);
        }

        public ICollection<DataPoint> Generate(int balance, int fraction, int win, int sigma)
        {
            var dataPoints = new Collection<DataPoint>();
            int i;
            try
            {
                using (var enumerator = new Class1(balance).GetValues(fraction / 100d, win / 100d, sigma / 100d).GetEnumerator())
                    for (enumerator.MoveNext(), i = 0; i < 100; enumerator.MoveNext())
                    {
                        dataPoints.Add(new DataPoint(i++, enumerator.Current));
                    }
            }
            catch(Exception ex)
            {

            }

            return dataPoints;
        }



        public ICommand Balance => balance;

        public ICommand Fraction => fraction;// new ReactiveProperty<int>(5);

        public ICommand Win => win;//new ReactiveProperty<int>(5);

        public ICommand Sigma => sigma;//new ReactiveProperty<int>(5);

        public ICollection<DataPoint> DataPoints => dataPoints.Value;



        public class Class1
        {
            private double balance;

            public Class1(double balance)
            {
                this.balance = balance;
            }

            public IEnumerable<double> GetValues(double a, double b, double c)
            {
                while (true)
                {
                    balance = Next(balance, a, b, c);
                    yield return balance;
                }
            }


            private double Next(double balance, double percentage, double win, double sigma)
            {

                var trandom = Troschuetz.Random.TRandom.New();
                return balance + (percentage * balance) * (trandom.Normal(win, sigma));

            }
        }


    }
}
