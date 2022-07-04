using ASPCoreFirstApp.Models;
using Bogus;

namespace ASPCoreFirstApp.Services
{
    public class HardCodedMovieDataRepository : IMoviesDataService
    {
        static List<MovieModel> moviesList;

        public HardCodedMovieDataRepository()
        {
            moviesList = new List<MovieModel>();
            moviesList.Add(new MovieModel(1, "Harry Potter", 5.99m, DateTime.Now));
            moviesList.Add(new MovieModel(2, "The Lion King", 45.59m, DateTime.Now));
            moviesList.Add(new MovieModel(3, "G Force", 130.00m, DateTime.Now));
            moviesList.Add(new MovieModel(4, "IT", 15.99m, DateTime.Now));

            for (int i = 0; i < 100; i++)
            {
                moviesList.Add(new Faker<MovieModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.ShowTime, f => f.Date.Between(DateTime.Now, DateTime.Now.AddDays(100))
                    ));
            }
        }



        public List<MovieModel> AllMovies()
        {
            return moviesList;
        }

        public bool Delete(MovieModel product)
        {
            throw new NotImplementedException();
        }

        public MovieModel GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(MovieModel product)
        {
            throw new NotImplementedException();
        }

        public List<MovieModel> SearchMovies(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(MovieModel product)
        {
            throw new NotImplementedException();
        }
    }
}
