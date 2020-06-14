using AutoMapper;
using Betting.Model;
using System;
using System.Linq;
using UtilityEnum.Betting;

namespace Betting.Map
{
    public class EntityToModelProfile : Profile
    {
        public EntityToModelProfile()
        {

            CreateMap<Betting.Entity.Sqlite.Market, Market>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => (MarketType)src.Key))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(src => src.Contracts.Select(_ => _.MapToModel())));


            CreateMap<Betting.Entity.Sqlite.Contract, Contract>()

                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Bids, opt => opt.MapFrom(src => src.Prices.Where(_ => _.Type == PriceType.Bid).Select(_ => _.MapToModel())))
                .ForMember(dest => dest.Offers, opt => opt.MapFrom(src => src.Prices.Where(_ => _.Type == PriceType.Offer).Select(_ => _.MapToModel())));

            CreateMap<Betting.Entity.Sqlite.Price, Price>()
                  .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Type))
                  .ForMember(dest => dest.Value, opt => opt.MapFrom(src =>GetOdd(src.Type,src.Value)));
                     

        }

        private Odd GetOdd(PriceType type, long value) => new Odd(type, (value > 100) ? UtilityStruct.ProbabilityEx.GetFromEuropeanOdd((value/100d)) :default);
    }
}
