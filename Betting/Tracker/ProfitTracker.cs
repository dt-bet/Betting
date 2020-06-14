using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using UtilityEnum;
using UtilityEnum.Betting;
using UtilityHelper;

namespace Betting
{


    public class ProfitTracker : IProfitTracker
    {
        public NodaMoney.Money runningProfits { get; set; }
        public NodaMoney.Money tempProfits { get; set; } = 0;
        public NodaMoney.Money amountSpent => amountspent;
        private NodaMoney.Money amountspent;

        public UtilityEnum.Betting.Side Side { get; }

        private string _contract;

        [Browsable(false)]
        public BetTracker Bets { get; set; }
        byte currentWeek = 0;
        public int InitialValue { get; set; }
        public byte week { get; set; } = 0;
        Bet bet;
        [Browsable(false)]
        public IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator mva { get; set; }

        private BetPlacer betPlacer;

        public ProfitTracker(UtilityEnum.Betting.Side os, string contract)
        {

            amountspent = 0;
            Side = os;
            _contract = contract;

            runningProfits = InitialValue;

            mva = IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator.Init(1);
        }

        public ProfitTracker(NodaMoney.Money initialvalue, DateTime start,  UtilityEnum.Betting.Side os, string contract)
        {
            try
            {
                Bets = new BetTracker(start, initialvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            amountspent = 0;
            Side = os;
            _contract = contract;

            runningProfits = initialvalue;
            InitialValue = (int)initialvalue;
            mva = IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator.Init(1);
            betPlacer = new BetPlacer();
        }

        public void Init(DateTime start, NodaMoney.Money initialvalue)
        {
            runningProfits = initialvalue;
            InitialValue = (int)initialvalue;
            try
            {
                Bets = new BetTracker(start, initialvalue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void UpdateWeek(byte week)
        {


            if (week != currentWeek)
            {
                currentWeek = week;
                mva = mva.Add((double)amountspent);
                amountspent = 0;
                runningProfits += tempProfits;
                tempProfits = 0;
                Bets.Total = runningProfits;


            }

        }

        public void ExecuteBet(DateTime date, bool b)
        {
            if (bet != null)
            {
                betPlacer.Execute(bet, runningProfits, ref amountspent);

                var profits = ProfitHelper.CalculateProfit(bet, date, b);

                tempProfits += profits;

                Bets.Series.Add(bet);
            }
        }

        public void ExecuteBet(DateTime date, ContractType type)
        {
            if (bet != null)
            {
                betPlacer.Execute(bet, runningProfits, ref amountspent);

                var profits = ProfitHelper.CalculateProfit(bet, date, type);

                tempProfits += profits;

                Bets.Series.Add(bet);
            }
        }

        public void ExecuteBet(DateTime date, NodaMoney.Money unitprofit)
        {
            if (bet != null)
            {
                betPlacer.Execute(bet, runningProfits, ref amountspent);

                var profits = ProfitHelper.CalculateProfit(bet, date, unitprofit>0);

                tempProfits += profits;

                Bets.Series.Add(bet);
            }
        }
        public void MakeBet(DateTime date, double arb, UtilityStruct.Probability price, UtilityEnum.Betting.Side side)
        {
            bet = BetFactory.Make(side, date, new NodaMoney.Money(arb), runningProfits, price, 0.1d, _contract);
        }

    
    }



















    //public class ProfitTracker<T>
    //{
    //    public int[] runningProfits { get; set; }
    //    public int[] tempProfits { get; set; }
    //    public int[] amountSpent => amountspent;

    //    public Tuple<BetTracker[], BetTracker[]> Bets { get; set; }
    //    byte currentWeek = 0;
    //    private int[] amountspent;
    //    public int InitialValue { get;  } 
    //    public byte week { get; set; } = 0;
    //    [Browsable(false)]
    //    public IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator[] mva { get; set; }

    //    //public ProfitTracker2[] ProfitTrackers2 { get; } = new ProfitTracker2[6];

    //    public ProfitTracker(int initialValue,DateTime date)
    //    {
    //        InitialValue = initialValue;
    //        Bets = Tuple.Create(
    //          Enumerable.Range(1, 3).Select(r => new BetTracker(date, InitialValue)).ToArray(),
    //             Enumerable.Range(1, 3).Select(r => new BetTracker(date, InitialValue)).ToArray());

    //        runningProfits = Enumerable.Range(1, 6).Select(r => InitialValue).ToArray();
    //        tempProfits = Enumerable.Range(1, 6).Select(r => 0).ToArray();
    //        amountspent = Enumerable.Range(1, 6).Select(r => 0).ToArray();
    //        mva = Enumerable
    //           .Range(1, 6)
    //           .Select(_ => IncrementalMeanVarianceAccumulator.MeanVarianceAccumulator.Init(1)).ToArray();
    //    }



    //    public void UpdateWeek(byte week)
    //    {
    //        if (week != currentWeek)
    //        {
    //            currentWeek = week;
    //            mva.ForEach((_, j) => mva[j] = _.Add(amountSpent[j]));
    //            amountSpent.ForEach((_, j) => amountSpent[j] = 0);
    //            tempProfits.ForEach((tp, j) => { runningProfits[j] += tempProfits[j]; tempProfits[j] = 0; });
    //            //Bets[0].ForEach((_, j) => Bets[j].Total = runningProfits[j]);

    //            for (int i = 0; i < 3; i++)
    //                Bets.Item1[i].Total = runningProfits[i];

    //            for (int i = 0; i < 3; i++)
    //                Bets.Item2[i].Total = runningProfits[i + 3];
    //        }

    //    }



    //    //public void Execute(Bet[] bets, IMatch match)
    //    //{

    //    //    Helper.ExecuteBets(bets, runningProfits, ref amountspent);

    //    //    var profits = Helper.CalculateProfits<IMatch>(bets, match, m => m.Date, m => m.FTR());

    //    //    tempProfits.ForEach((tp, j) => tempProfits[j] += profits[j]);


    //    //    for (int i = 0; i < 3; i++)
    //    //        Bets.Item1[i].Series.Add(bets[i]);

    //    //    for (int i = 0; i < 3; i++)
    //    //        Bets.Item2[i].Series.Add(bets[i + 3]);


    //    //}


    //    public void Execute(Bet[] bets, T match, Func<T, DateTime> date, Func<T, string> ftr)
    //    {

    //        Helper.ExecuteBets(bets, runningProfits, ref amountspent);

    //        var profits = Helper.CalculateProfits<T>(bets, match,date,  ftr);

    //        tempProfits.ForEach((tp, j) => tempProfits[j] += profits[j]);


    //        for (int i = 0; i < 3; i++)
    //            Bets.Item1[i].Series.Add(bets[i]);
    //        if (bets.Count() > 3)
    //            for (int i = 0; i < 3; i++)
    //                Bets.Item2[i].Series.Add(bets[i + 3]);


    //    }



    //    public Bet[] MakeBets(T match, Func<T,DateTime> date,Func<T,decimal[]> backprices, Func<T, decimal[]> layprices, double[] arb)
    //    {

    //        //decimal[] backPrices = match.ExtractHDAPrice();
    //        //decimal[] layPrices = match.ExtractHDAPriceAsLay((decimal)1.1);


    //        var pcr = Bets.Item1.Select(_ => _.PercentAtRisk).ToArray();
    //        var x = Helper.MakeBackBets(date(match), arb,  runningProfits, week, backprices(match), pcr);



    //        if (arb.Length == 6)
    //        {
    //            arb = arb.Skip(3).ToArray();

    //        }

    //        pcr = Bets.Item2.Select(_ => _.PercentAtRisk).ToArray();
    //        Bet[] y = Helper.MakeLayBets(date(match), arb,  runningProfits.Skip(3).ToArray(), week, layprices(match), pcr);

    //        Bet[] z = new Bet[6];

    //        z[0] = x[0];
    //        z[1] = x[1];
    //        z[2] = x[2];
    //        z[3] = y[0];
    //        z[4] = y[1];
    //        z[5] = y[2];


    //        return z;

    //    }


    //public Bet[] MakeBets(Bet365Match match, double[] arb, double[] prob)
    //{

    //    decimal[] backPrices = MatchExtension.ExtractHDAOdds(match).Select(_ => _.Price).ToArray();
    //    //decimal[] layPrices = match.ExtractHDAPriceAsLay((decimal)1.1);


    //    var pcr = Bets.Item1.Select(_ => 0.01 * _.PercentAtRisk).ToArray();
    //    var x = Helpers.MakeBackBets(match.Date, arb, prob, runningProfits, week, backPrices, pcr);


    //    if (arb.Length == 6)
    //    {
    //        arb = arb.Skip(3).ToArray();

    //    }
    //    pcr = Bets.Item2.Select(_ => _.PercentAtRisk).ToArray();

    //    //Bet[] y = Helpers.MakeLayBets(match.Date, arb, prob, runningProfits.Skip(3).ToArray(), week, layPrices, pcr);

    //    Bet[] z = new Bet[3];

    //    z[0] = x[0];
    //    z[1] = x[1];
    //    z[2] = x[2];
    //    //z[3] = y[0];
    //    //z[4] = y[1];
    //    //z[5] = y[2];


    //    return z;

    //}


    //}
}
