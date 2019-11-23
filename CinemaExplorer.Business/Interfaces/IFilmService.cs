using CinemaExplorer.Persisted.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaExplorer.Business.Interfaces
{
    public interface IFilmService : IGenericService<Film>
    {
        Task<List<Film>> GetAllByIds(List<Guid> ids);
    }
}
