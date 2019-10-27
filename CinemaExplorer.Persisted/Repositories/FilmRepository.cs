using CinemaExplorer.Persisted.Context;
using CinemaExplorer.Persisted.Entities;
using CinemaExplorer.Persisted.Interfaces;

namespace CinemaExplorer.Persisted.Repositories
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(CinemaContext context) : base(context)
        {

        }
    }
}
