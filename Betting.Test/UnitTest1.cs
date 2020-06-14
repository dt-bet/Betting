using System;
using Xunit;
using System.Linq;
using FizzWare.NBuilder;
using System.Collections.Generic;
using UtilityEnum.Betting;

namespace Betting.Test
{
    public class UnitTest1
    {
       static IListBuilder<Entity.Sqlite.Price> priceBuild = FizzWare.NBuilder.Builder<Entity.Sqlite.Price>.CreateListOfSize(10);

        static ISingleObjectBuilder<Entity.Sqlite.Contract> contractBuild = FizzWare.NBuilder.Builder<Entity.Sqlite.Contract>.CreateNew().With(x => x.Prices = priceBuild.Build().ToList());

        static ISingleObjectBuilder<Entity.Sqlite.Market> marketBuild = FizzWare.NBuilder.Builder<Entity.Sqlite.Market>.CreateNew().With(x => x.Contracts = Enumerable.Range(0, 4).Select(_ => contractBuild.Build()).ToList());


        [Fact]
        public void Test1()
        { 
            var market = Map.Mapper.MapToModel(marketBuild.Build());
        }

        [Fact]
        public void Test2()
        {
            var contract = Map.Mapper.MapToModel(contractBuild.Build());
        }

        [Fact]
        public void Test3()
        {
            var price = priceBuild.Build().Select(_=>Map.Mapper.MapToModel(_)).ToArray();
        }



        [Fact]
        public void Test4()
        {
            var odd = new Model.Odd(Enum.PriceType.Bid,new UtilityStruct.Probability(70)); ;

        }


        [Fact]
        public void Test6()
        {
            var odd = new Odd(PriceType.Bid,new UtilityStruct.Probability(0.4));
            var profit = ProfitHelper.GetUnitProfit(odd, UtilityEnum.Resolution.For, 0.8m);
    
        }


    }
}
