using ASPCoreFirstApp.Models;

namespace ASPCoreFirstApp.Services
{
    public interface IMoviesDataService
    {
        List<MovieModel> AllMovies();
        List<MovieModel> SearchMovies(string searchTerm);
        MovieModel GetMovieById(int id);
        int Insert(MovieModel movie);
        bool Delete(MovieModel movie);
        int Update(MovieModel movie);
    }
}
