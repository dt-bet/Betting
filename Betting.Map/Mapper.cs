using AutoMapper;
using Betting.Model;
using System;
using System.Linq;
using Betting.Enum;

namespace Betting.Map
{



    public static class Mapper
    {
        private static IMapper _mapper;

        static Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Int64, DateTime>().ConvertUsing(x => new DateTime(x));
                cfg.CreateMap<Int64, Double>().ConvertUsing(x => (((double)x) / 100));
                cfg.CreateMap<DateTime, long>().ConvertUsing(x => x.Ticks);
                cfg.CreateMap<double,long>().ConvertUsing(x => (long)(x * 100));

                cfg.AddProfile<ModelToEntityProfile>();
                cfg.AddProfile<EntityToModelProfile>();
            });

            _mapper = config.CreateMapper();
        }


        public static Betting.Entity.Sqlite.Market MapToEntity(this Market fdm)
        {
            return _mapper.Map<Market, Betting.Entity.Sqlite.Market>(fdm);


        }

        public static Betting.Entity.Sqlite.Contract MapToEntity(this Contract fdm)
        {
            return _mapper.Map<Contract, Betting.Entity.Sqlite.Contract>(fdm);


        }


        public static Betting.Entity.Sqlite.Price MapToEntity(this Price price, PriceSide PriceSide)
        {
            var map = _mapper.Map<Price, Betting.Entity.Sqlite.Price>(price);
            map.Side =  PriceSide;
            return map;

        }
     

        public static Market MapToModel(this Betting.Entity.Sqlite.Market fdm)
        {
            return _mapper.Map<Betting.Entity.Sqlite.Market,Market>(fdm);


        }

        public static Contract MapToModel(this Betting.Entity.Sqlite.Contract fdm)
        {
            return _mapper.Map<Betting.Entity.Sqlite.Contract,Contract>(fdm);


        }

        public static Price MapToModel(this Betting.Entity.Sqlite.Price price)
        {
            var map = _mapper.Map<Betting.Entity.Sqlite.Price, Price>(price);
            return map;
        }

    }





}