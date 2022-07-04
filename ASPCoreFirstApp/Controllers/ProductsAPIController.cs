using ASPCoreFirstApp.Models;
using ASPCoreFirstApp.Services;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ASPCoreFirstApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsAPIController : ControllerBase
    {
        ProductsDAO repository = new ProductsDAO();

        [HttpGet]
        public IEnumerable<ProductDTO> Index()
        {
            List<ProductModel> products = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOList =
                from product in products
                select
                new ProductDTO(product.Id, product.Name, product.Price, product.Description);

            return productDTOList;
        }

        [HttpGet("searchresults/{searchTerm}")]
        public IEnumerable<ProductDTO> SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);

             IEnumerable<ProductDTO> productDTOList =
                from product in productList
                select
                new ProductDTO(product.Id, product.Name, product.Price, product.Description);

            return productDTOList;
        }

        [HttpGet("showoneproduct/{Id}")]
        public ActionResult<ProductDTO> ShowOneProduct(int Id)
        {
            ProductModel product = repository.GetProductById(Id);

            ProductDTO productDTO = new(product.Id, product.Name, product.Price, product.Description);

            return productDTO;
        }

        [HttpPut("processedit")]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product)
        {
            repository.Update(product);
            List<ProductModel> products = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOList =
                from p in products
                select
                new ProductDTO(p.Id, p.Name, p.Price, p.Description);

            return productDTOList;
        }

        [HttpPut("ProcessEditReturnOneItem")]
        public ActionResult<ProductDTO> ProcessEditReturnOneItem(ProductModel product)
        {
            repository.Update(product);
            ProductModel foundProduct = repository.GetProductById(product.Id);
            ProductDTO productDTO = new(foundProduct.Id, foundProduct.Name, foundProduct.Price, foundProduct.Description);
            return productDTO;
        }



    }
}
