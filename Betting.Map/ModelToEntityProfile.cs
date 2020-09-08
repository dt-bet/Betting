using AutoMapper;
using Betting.Model;
using System;
using System.Linq;
using Betting.Enum;

namespace Betting.Map
{

    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<Market, Betting.Entity.Sqlite.Market>()
               // .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Contracts, opt => opt.MapFrom(src => src.Contracts.Select(_ => _.MapToEntity())));


            CreateMap<Contract, Betting.Entity.Sqlite.Contract>()
                //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Prices, opt => opt.MapFrom(src => src.Bids.Select(_ => _.MapToEntity((PriceSide.Bid))).Concat(src.Offers.Select(_ => _.MapToEntity((PriceSide.Offer))))));

            CreateMap<Price, Entity.Sqlite.Price>();
            //.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Type));
        }
    }
}
