using AutoMapper;
using Betting.Model;
using System;
using System.Linq;
using Betting.Enum;
using UtilityStruct;

namespace Betting.Map
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {

            CreateMap<Betting.Entity.Sqlite.Market, Market>()
                //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => (MarketType)src.Type))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(src => src.Contracts.Select(c => c.MapToModel())));


            CreateMap<Betting.Entity.Sqlite.Contract, Contract>()

                //.ForMember(dest => dest.SelectionName, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Bids, opt => opt.MapFrom(src => src.Prices.Where(_ => _.Side == PriceSide.Bid).Select(_ => _.MapToModel(PriceSide.Bid))))
                .ForMember(dest => dest.Offers, opt => opt.MapFrom(src => src.Prices.Where(_ => _.Side == PriceSide.Offer).Select(_ => _.MapToModel(PriceSide.Offer))));

            CreateMap<Betting.Entity.Sqlite.Price, Price>()
                  //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Side))
                  .ForMember(dest => dest.Value, opt => opt.MapFrom(src => GetOdd(src.Side, src.Value)));

        }

        private Odd GetOdd(PriceSide type, long value) => new Odd(
            type switch { PriceSide.Bid => Odd.PriceType.Bid, PriceSide.Offer => Odd.PriceType.Offer, PriceSide.None => Odd.PriceType.Offer, _ => throw new NotImplementedException() }, 
            (value > 100) ? ProbabilityEx.GetFromEuropeanOdd((value / 100d)) : default);
    }
}
