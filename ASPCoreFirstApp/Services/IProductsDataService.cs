using ASPCoreFirstApp.Models;

namespace ASPCoreFirstApp.Services
{
    public interface IProductsDataService
    {
        List<ProductModel> AllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);
        bool Delete(int productId);
        int Update(ProductModel product);
    }
}
