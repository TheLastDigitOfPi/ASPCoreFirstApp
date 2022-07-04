using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ASPCoreFirstApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO repository = new ProductsDAO();
        public ProductsController()
        {
            repository = new ProductsDAO();
        }

        public IActionResult Index()
        {
            return View(repository.AllProducts());
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> prodictList = repository.SearchProducts(searchTerm);
            return View("Index", prodictList);
        }

        public IActionResult ShowOneProduct(int Id)
        {
            return View(repository.GetProductById(Id));
        }

        public IActionResult ShowOneProductJSON(int Id)
        {
            return Json(repository.GetProductById(Id));
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            return View("Index", repository.AllProducts());
        }

        public IActionResult ProcesseditReturnPartial(ProductModel product)
        {
            repository.Update(product);
            return PartialView("_productCard", product);
        }

        public IActionResult ShowEditForm(int Id)
        {
            return View(repository.GetProductById(Id));
        }
        

        public IActionResult DeleteItem(int Id)
        {
            repository.Delete(Id);
            return View("Index", repository.AllProducts());
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            // HttpUtility.HtmlEncode("Hello " + name + " the secret number is " + secretNumber);
            ViewBag.name = "Chad";
            ViewBag.secretNumber = 13;
            return View();
        }
    }
}
