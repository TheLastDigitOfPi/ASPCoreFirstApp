using ASPCoreFirstApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreFirstApp.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            HardCodedMovieDataRepository repository = new HardCodedMovieDataRepository();
            return View(repository.AllMovies());
        }
    }
}
