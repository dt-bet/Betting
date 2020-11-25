using System;
using System.Collections;
using System.Collections.Generic;
using Betting.Abstract;
using Betting.Entity.Sqlite;
using Bogus;

namespace Betting.Faker
{
    public class Factory
    {


        public Factory()
        {
        }

        public static Faker<Price> FakerPrice => new Faker<Price>().RuleFor(a => a.Guid, f => f.Random.Guid())
                  .RuleFor(a => a.Id, f => f.IndexGlobal)
                  .RuleFor(a => a.Guid, f => f.Random.Guid())
                  .RuleFor(a => a.MarketId, f => f.Random.Guid())
                  .RuleFor(a => a.OddId, f => f.Random.Guid())
                  .RuleFor(a => a.SelectionId, f => f.Random.Guid())
                  .RuleFor(a => a.SelectionName, f => f.Name.FirstName())
                  .RuleFor(a => a.Side, f => Enum.PriceSide.Offer)
                  .RuleFor(a => a.Value, f => f.Random.UInt(1, 1000));

        public static Faker<Odd> FakerOdd => new Faker<Odd>().RuleFor(a => a.CompetitionId, f => f.Random.Guid())
                      .RuleFor(a => a.EventDate, f => DateTime.UnixEpoch + TimeSpan.FromDays(f.IndexGlobal))
                      .RuleFor(a => a.Guid, f => f.Random.Guid())
                      .RuleFor(a => a.Id, f => f.IndexGlobal)
                      .RuleFor(a => a.MarketId, f => f.Random.Guid())
                      .RuleFor(a => a.OddsDate, f => DateTime.UnixEpoch + TimeSpan.FromDays(f.IndexGlobal - f.Random.Number(0, 14)))
                      .RuleFor(a => a.Prices, f => FakerPrice.Generate(3));

        public static Faker<Strategy> FakerStrategy => new Faker<Strategy>()
            .RuleFor(a => a.Guid, f => f.Random.Guid())
              .RuleFor(a => a.Name, f => f.Lorem.Word())
              .RuleFor(a => a.Description, f => f.Lorem.Paragraph());


    }
}
