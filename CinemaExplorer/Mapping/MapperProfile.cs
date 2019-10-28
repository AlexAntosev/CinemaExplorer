using AutoMapper;
using CinemaExplorer.Models;
using CinemaExplorer.Persisted.Entities;
using System.Collections.Generic;

namespace CinemaExplorer.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FilmModel, Film>();
            CreateMap<Film, PriceModel>()
                .ForMember(_ => _.FilmId, opts => opts.MapFrom(src => src.Id));
        }
    }
}
