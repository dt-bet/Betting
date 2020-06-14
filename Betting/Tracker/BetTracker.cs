using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityMath.Statistics;

namespace Betting
{

    public class BetTracker
    {
        int cnt = 0;


        DateTime startDate;

        public NodaMoney.Money Total { get; set; }

        public double AddedDeviation { get; set; } = 2.0;

        public ObservableCollection<Bet> Series { get; } = new ObservableCollection<Bet>();
        public ObservableCollection<Tuple<double, DateTime>> NetProfits { get; }
        public ObservableCollection<MathNet.Numerics.Distributions.Normal> ProfitSeries { get; } = new ObservableCollection<MathNet.Numerics.Distributions.Normal>();

        public MathNet.Numerics.Distributions.Normal NetProfit
        {
            get { return AverageProfit.Minus(BaseProfit); }
        }

        public MathNet.Numerics.Distributions.Normal AverageProfit { get; private set; } = new MathNet.Numerics.Distributions.Normal(0, 1);
        public MathNet.Numerics.Distributions.Normal BaseProfit { get; } = new MathNet.Numerics.Distributions.Normal(0, 1);





        public BetTracker(DateTime date, NodaMoney.Money total)
        {

            startDate = date;
            Total = total ;
            AverageProfit = new MathNet.Numerics.Distributions.Normal(1, 10);
            //mva = IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator.Init(1);
            NetProfits = new ObservableCollection<Tuple<double, DateTime>>();
            //Series.CollectionChanged += Series_CollectionChanged;
        }

        //private void Series_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.NewItems != null)
        //        if (e.NewItems.Count > 0)
        //            foreach (var item in e.NewItems)
        //            {
        //                //ReEvaluateProfitability((Bet)item);

        //            }
        //}


        //private void ReEvaluateProfitability(Bet bet)
        //{


        //    //cnt++;
        //    //if (cnt == 4)
        //    //{

        //    //}

        //    if (bet.Price == 0)
        //        return;
        //    else
        //    {
        //        //BaseProfit = BaseProfit.Multiply(new MathNet.Numerics.Distributions.Normal((double)(bet.UnitProfit / 1), stdDev));
        //        // calculate new normal
        //        if (bet.Amount > 0)
        //        {
        //            mva = mva.Add((double)(bet.UnitProfit() / bet.UnitLiability()));
        //            double stdDev = mva.StandardDeviation == 0 ? 1 : mva.StandardDeviation;

        //            AverageProfit = AverageProfit.Multiply(new MathNet.Numerics.Distributions.Normal((double)(bet.UnitProfit() / bet.UnitLiability()), stdDev));

        //            // add variance to keep model fresh
        //            AverageProfit.Add(new MathNet.Numerics.Distributions.Normal(0, AddedDeviation));


        //            //NetProfits.Add(new Tuple<double, DateTime>(NetProfit.Mean, bet.StartTime));
        //        }
        //        double stdDev2 = mva.StandardDeviation == 0 ? 1 : mva.StandardDeviation;
        //        BaseProfit.Multiply(new MathNet.Numerics.Distributions.Normal((double)(bet.UnitProfit() / 1), stdDev2));


        //    }
        //}



        //decimal percentAtRisk { get { if (NetProfit.Mean > 0) return (decimal)(NetProfit.Mean / (NetProfit.StdDev * 100)); else return 0; } }

        //IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator mva;

        //public double StandardDeviation { get { return mva.StandardDeviation == 0 ? 1 : mva.StandardDeviation; } }

        //public double PercentAtRisk { get {return NetProfit.Mean>0? NetProfit.Mean /(Math.Pow(NetProfit.StdDev,2)):0; } }

        //public double PercentAtRisk { get { return Math.Exp(NetProfit.Mean / (NetProfit.StdDev * 100)); } }
        //public double PercentAtRisk { get { return 0.5; } }
        public double PercentAtRisk
        {
            get


            {
                return 1;
                //if (AverageProfit.Mean > 0)
                //    return AverageProfit.Mean / (Math.Pow(AverageProfit.StdDev, 1)) * 0.1;
                //////if (NetProfit.Mean > 0)
                //////    return 5 * NetProfit.Mean / (Math.Pow(NetProfit.StdDev, 1));
                //else
                //    return 0.00;
            }
        }
    }


}
