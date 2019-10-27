using CinemaExplorer.Persisted.Context;
using CinemaExplorer.Persisted.Interfaces;
using System.Threading.Tasks;

namespace CinemaExplorer.Persisted.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaContext _context;

        private IFilmRepository _filmRepository;

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
        }

        public IFilmRepository FilmRepository => _filmRepository ?? (_filmRepository = new FilmRepository(_context));

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
