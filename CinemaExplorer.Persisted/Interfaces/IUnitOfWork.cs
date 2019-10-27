using System.Threading.Tasks;

namespace CinemaExplorer.Persisted.Interfaces
{
    public interface IUnitOfWork
    {
        IFilmRepository FilmRepository { get; }

        Task CommitAsync();
    }
}
