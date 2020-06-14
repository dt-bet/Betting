using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using UtilityStruct;

namespace Betting.Math
{

    public static class ProbabilityHelper
    {
        public static List<Probability> ToProbabilities(this decimal[] odds)
        {
            List<Probability> newProbs = new List<Probability>();

            decimal sum = 0;

            foreach (decimal o in odds)
            {
                if (o < 1) throw new Exception("values are not odds ");
                sum += 1 / o;
            }

            //decimal diff = 1/ sum; // e.g 1.023

            foreach (decimal o in odds)
            {
                newProbs.Add(new Probability(1 / (o * sum)));
            }

            return newProbs;

        }


        public static Normal ToGaussian(Probability homeProbability, Probability drawProbability, Probability awayProbability)
        {
            var limits = new double[2] { -0.5, 0.5 };
            var probabilities = new[] { awayProbability, drawProbability, homeProbability };
            return ToGaussian(probabilities.Select(_=>(double)_.Decimal), limits);
        }


        public static Normal ToGaussian(this IEnumerable<double> probabilities, double[] limits = null)
        {


            var x = InverseProbabilityDensities(probabilities, limits);

            //http://staff.argyll.epsb.ca/jreed/math30p/statistics/normal%20.htm
            // z-score (standard normal inverse)
            // indicates (see 1) how many standard deviations a value is from the mean. 
            // Equal to X when mean, μ,=0 and  standard deviation, σ, =1  i.e X=0.5 translates to z=0.5 or 50% of the standard deviation

            //  z = (X - μ) / σ 

            //http://accord-framework.net/docs/html/M_Accord_Statistics_Distributions_Univariate_NormalDistribution_InverseDistributionFunction.htm
            // Inverse Cumulative Distribution Function(ICDF) (see 2) :
            // specifies, for a given probability, p, the value which the random variable takes.
            // Its derivation requires rearraging (1):
            // 
            // I(p) = μ*1 + σ*ICDF(p) (where ICDF(p) is standard normal inverse  a.k.a z-score ) (2)
            //
            // multiple ICDF gives simultaneous equations with  μ  & σ as its variables
            // In the case of football it is equivalent to the goal difference between teams for a given probability.
            // Since for football two such equations can be made from available betting odds (i.e hometeam odds and awayteam odds)
            // a simultaneous equation can be made

            // also https://math.stackexchange.com/questions/1846199/how-to-calculate-inverse-cumulative-distribution-using-a-table


            // {1 , z1} * { μ } = { X1 }
            // {1 , z2}   { σ }   { X2 }


            var col1 = Enumerable.Repeat(1.0, limits.Length);
            var col2 = x.Select(yy => yy.ICDF);

            var A = Matrix<double>.Build.DenseOfColumns(new List<IEnumerable<double>> { col1, col2 });
            // {1 , z1}
            // {1 , z2}

            var b = Vector<double>.Build.DenseOfEnumerable(x.Select(yy => yy.Limit));
            //{ X1, X2}

            var solution = A.Solve(b);
            // { μ , σ}
            return new MathNet.Numerics.Distributions.Normal(solution[0], solution[1]);

        }

        public static Probability[] FromGaussian(double mean, double stddev, double[] limits = null) => new Normal(mean, stddev).ToProbabilities(limits);


        public static Probability[] ToProbabilities(this Normal normal, double[] limits = null)
        {
            limits = limits ?? new double[2] { -0.5, 0.5 };

            double lim = 0;
            List<double> probabilities = new List<double>();

            foreach (var limit in limits)
            {
                double prob = normal.CumulativeDistribution(limit) - lim;
                lim += prob;
                probabilities.Add(prob);
            }


            probabilities.Add(1 - lim);

            return probabilities.Select(_=>new Probability((decimal)_)).ToArray();

        }

        public static Normal MakeGaussian(double probability, double limit, double stdDev)
        {

            //  z = (X - μ) / σ 

            double X = limit;

            double ICDF = NormalExtension.InverseCumulativeDistributionFunction(probability);
            double mean = X - ICDF * stdDev;

            return new MathNet.Numerics.Distributions.Normal(mean, stdDev);

        }


        public static List<InverseNormal> InverseProbabilityDensities(IEnumerable<double> probabilities, double[] limits)
        {


            int lcount = limits.Length;
            int i = 0;
            List<InverseNormal> invN = new List<InverseNormal>();

            Array.Sort(limits);
            double area;

            double cumArea = 0;

            using (IEnumerator<double> enumerator = probabilities.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    // since the sum of the area will be 1 the last probability is redundant
                    if (i < lcount)
                    {
                        area = enumerator.Current;

                        cumArea += area;

                        InverseNormal inv = new InverseNormal() { Limit = limits[i], Area = cumArea };
                        invN.Add(inv);

                    }
                    i++;
                }

            }

            // System.Diagnostics.Debug.Assert(limits.Length == i - 1);

            return invN;


            //while (i < lcount)
            //{
            //    while (enumerator.MoveNext())

            //        area = 1.00 / probabilities[i];

            //    cumArea += area;

            //    InverseNormal inv = new InverseNormal() { ZScore = limits[i], Area = cumArea };
            //    invN.Add(inv);
            //    i++;
            //}


        }


        public struct InverseNormal
        {
            //private Accord.Statistics.Distributions.Univariate.NormalDistribution normalDistribution=new Accord.Statistics.Distributions.Univariate.NormalDistribution();
            //public Contract Contract { get; set; }
            public double Limit { get; set; }
            public double Area { get; set; }
            public double ICDF
            {
                get
                {
                    // area under the cumulative normal function from negative infinity to ZScore is equivalant probability
                    return NormalExtension.InverseCumulativeDistributionFunction(Area);
                }
            }




        }

        public class NormalExtension
        {

            public static double InverseCumulativeDistributionFunction(double probability)
            {
                //var x = new Accord.Statistics.Distributions.Univariate.NormalDistribution();
                //return x.InverseDistributionFunction(probability);
                var normal = new MathNet.Numerics.Distributions.Normal();
                return normal.InverseCumulativeDistribution(probability);
            }



        }

    }





}






public static class Maths
{




    //public static decimal[] ProbabilityDensities(decimal mean, decimal variance, decimal[] limits)
    //{
    //    int lcount = limits.Length;
    //    decimal[] probabilityDensities = new decimal[lcount + 1];
    //    int i = 1;

    //    Array.Sort(limits);

    //    // var normal = new Accord.Statistics.Distributions.Univariate.NormalDistribution(g.Mean, g.StandardDeviation);


    //    //probabilityDensities[0] = normal.DistributionFunction(limits[0]);
    //    probabilityDensities[0] = CumulativeDistributionFunction.CumulativeDensity(mean, variance, limits[0]);
    //    while (i < lcount)
    //    {
    //        // probabilityDensities[i] = normal.DistributionFunction(limits[i - 1], limits[i]);
    //        probabilityDensities[i] =
    //       CumulativeDistributionFunction.CumulativeDensity(mean, variance, limits[i]) -
    //       CumulativeDistributionFunction.CumulativeDensity(mean, variance, limits[i - 1]);
    //        i++;
    //    }

    //    //probabilityDensities[lcount] = 1 - normal.DistributionFunction(limits[lcount - 1]);
    //    probabilityDensities[lcount] = 1 - CumulativeDistributionFunction.CumulativeDensity(mean, variance, limits[lcount - 1]);
    //    return probabilityDensities;
    //}








    //public static InverseNormal[] GenerateInvertedNormalDistributions(decimal[] limits, decimal[] probabiliies)
    //{

    //    // //
    //    //   |   //                                                                                                                                                             ..
    //    //|    |   |  //                                                                                                                                                               ..
    //    //  |    |   |    //                                                                                                                                                             ..
    //    //    |    |   |      //                                                                                                                                                           ..
    //    ////      |    |   |        ////     
    //    //................................
    //    //       -0.5   0   0.5


    //    var x = new InverseNormal[2];
    //    // this represents the area/probability of the normal distribution  where the home-team win
    //    // for the home team to win they would need to score 0.5 or more goals than their oppoenent
    //    x[0] = new InverseNormal()
    //    {
    //        ZScore = 0.5,
    //        Area = 1 - (1.00 / Home.PerfectOdds)
    //    };
    //    //  this represents the area/probability of the normal distribution  where the home-team win
    //    // for the away team to win they would need to score 0.5 or more goals than their oppoenent
    //    x[1] = new InverseNormal()
    //    {
    //        ZScore = -0.5,
    //        Area = 1.00 / Away.PerfectOdds
    //    };

    //    return x;
    //}



    //private MathNet.Numerics.Distributions.Normal gaussian;

    //public static MathNet.Numerics.Distributions.Normal Gaussian
    //{
    //    get
    //    {
    //        if (gaussian == null)
    //        {

    //            //http://staff.argyll.epsb.ca/jreed/math30p/statistics/normal%20.htm
    //            // z-score (standard normal inverse)
    //            // indicates (see 1) how many standard deviations a value is from the mean. 
    //            // Equal to X when μ=0 and σ=1  i.e X=0.5 translates to z=0.5 or 50% of the standard deviation

    //            //  z = (X - μ) / σ (1)

    //            //http://accord-framework.net/docs/html/M_Accord_Statistics_Distributions_Univariate_NormalDistribution_InverseDistributionFunction.htm
    //            // Inverse Cumulative Distribution Function(ICDF) (see 2) :
    //            // specifies, for a given probability, the value which the random variable takes.
    //            // Its derivation requires rearraging (1):
    //            // 
    //            // ICDF(p) = μ + σ* I(p) (where I(p) is standard normal inverse a.k.a z-score ) (2)
    //            //
    //            // multiple ICDF gives simultaneous equations with  μ  & σ as its variables
    //            // In the case of football it is equivalent to the goal difference between teams for a given probability.
    //            // Since for football two such equations can be made from available betting odds (i.e hometeam odds and awayteam odds)
    //            // a simultaneous equation can be made


    //            var inv = GenerateInvertedNormalDistributions();
    //            var solution = Maths.LinearEquations.SolveSimultaneous(1, inv[0].IDF, 1, inv[1].IDF, inv[0].ZScore, inv[1].ZScore);
    //            this.gaussian = new Statistics.Distributions.Gaussian(solution.Item2, solution.Item1);
    //        }

    //        return gaussian;
    //    }
    //}


}





