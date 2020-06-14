using OxyPlot;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.ViewModel
{
    public class BalanceViewModel
    {
        public ReactiveProperty<ICollection<DataPoint>> DataPoints { get; } 

        public ReactiveProperty<int> Balance { get; } = new ReactiveProperty<int>(100);

        public ReactiveProperty<int> Fraction { get; } = new ReactiveProperty<int>(5);

        public ReactiveProperty<int> Win { get; } = new ReactiveProperty<int>(5);

        public ReactiveProperty<int> Sigma { get; } = new ReactiveProperty<int>(5);


        public BalanceViewModel()
        {
            DataPoints = Balance.CombineLatest(Fraction,Win,Sigma,
                (a,b,c,d)=> 
                Init(a,b,c,d)).ToReactiveProperty();
      
        }

        public ICollection<DataPoint> Init(int balance, int fraction,int win, int sigma)
        {
            var dataPoints = new Collection<DataPoint>();
            int i;
            using (var enumerator = new Betting.Math.Class1(balance).GetValues(fraction/100d,win/100d,sigma/100d).GetEnumerator())
                for (enumerator.MoveNext(), i = 0; i < 100; enumerator.MoveNext())
                {
                    dataPoints.Add(new DataPoint(i++, enumerator.Current));
                }

            return dataPoints;
        }
    }
}
