using Betting.Model;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityEnum.Betting;
using UtilityStruct;

namespace Betting.Factory
{
    public static class PriceFactory
    {
        private static Random random;
        static RandomGenerator randomGenerator;
        static System.Collections.Generic.IEnumerator<DateTime> en;
        static System.Collections.IEnumerator str;
        static Dictionary<string, int> dictionary=new Dictionary<string, int>();

        static PriceFactory()
        {
            random = new Random();
            randomGenerator = new RandomGenerator();
            en = dates().GetEnumerator();
            str = (new string[] { "a", "b", "c" }).GetEnumerator();
        }

        public static IOperable<Price> WithDefaults(this IOperable<Price> operable)
        {
            ((IDeclaration<Price>)operable).ObjectBuilder
               .With(x => x.Source = randomGenerator.Enumeration<PriceSource>())
           .With(x => x.Value = new Odd(new UtilityStruct.Probability(randomGenerator.Next(1, 100))))
           .With(x => x.Time = GetNext())
            .With(x => x.Key = randomGenerator.Enumeration<ContractType>());

            return operable;
        }

        public static IOperable<Price> WithDefaults(this IOperable<Price> operable,string name)
        {
            ((IDeclaration<Price>)operable).ObjectBuilder
               .With(x => x.Source = randomGenerator.Enumeration<PriceSource>())
           .With(x => x.Value = new Odd(UtilityStruct.ProbabilityEx.GetFromEuropeanOdd(GetNextValue(name))))
           .With(x => x.Time = GetNext())
            .With(x => x.Key = ContractType.Home);

            return operable;
        }

        public static double GetNextValue(string name)
        {
            if (!dictionary.ContainsKey(name))
                dictionary[name] = randomGenerator.Next(1, 20);

            return dictionary[name] + random.NextDouble()*dictionary[name]/2;
        }

        public static System.Collections.Generic.IEnumerable<Price> GetPrices(int number = 20)
        {

            return Builder<Price>
         .CreateListOfSize(number)
         .All()
         .WithDefaults()
         .Build();
        }


        public static System.Collections.Generic.IEnumerable<Price> GetPrices(int number = 20,string name="a")
        {

            return Builder<Price>
         .CreateListOfSize(number)
         .All()
         .WithDefaults(name)
         .Build();
        }
        public static System.Collections.Generic.IEnumerable<Price> GetManyPrices(int number = 20)
        {

            return  (new string[] { "a", "b", "c" }).Select(_=>Builder<Price>
         .CreateListOfSize(number)
         .All()
         .WithDefaults(_)
         .Build()).SelectMany(_=>_);
        }


        static DateTime GetNext()
        {
            en.MoveNext();
            return en.Current;
        }

        static string GetNextName()
        {
            str.MoveNext();
            return str.Current.ToString();
        }


        static System.Collections.Generic.IEnumerable<DateTime> dates()
        {
            int i = 0;
            var dtn = DateTime.Now;
            while (true)
                yield return dtn.AddDays(i++);
        }


    }
}
