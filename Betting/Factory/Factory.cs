using Betting.Model;
using RandomTestValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Factory
{
    public static class Factory
    {
        static Factory()
        {
            RandomValueSettings randomValueSettings = new RandomValueSettings();
        }

        public static Price GetPrice()
        {
            return RandomValue.Object<Price>();
        }

        public static IEnumerable<Price> GetPrices(int number)
        {
            return RandomValue.IEnumerable<Price>(number);
        }

        public static IEnumerable<Recommendation> GetRecommendations(int number)
        {
            return RandomValue.IEnumerable<Recommendation>(number);
        }

        public static IEnumerable<Balance> GetBalances(int number)
        {
            return RandomValue.IEnumerable<Balance>(number);
        }
    }
}
