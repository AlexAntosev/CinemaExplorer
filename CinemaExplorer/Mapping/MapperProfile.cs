using AutoMapper;
using CinemaExplorer.Models;
using CinemaExplorer.Persisted.Entities;

namespace CinemaExplorer.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FilmModel, Film>();
        }
    }
}
