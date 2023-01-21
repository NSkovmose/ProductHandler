using ProductHandler.Models;

namespace ProductHandler.Services
{
    public interface IProductService
    {
        public Task<List<ProductModel>> GetAllProducts();
        public Task<ProductModel> GetProduct(int? id);
        public Task DeleteProduct(int? id);
        public Task EditProduct(ProductModel productModel);
        public Task SaveProduct(ProductModel productModel);
    }
}
