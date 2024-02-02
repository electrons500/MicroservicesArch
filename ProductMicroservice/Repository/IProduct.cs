using ProductMicroservice.Models.Data.MicroserviceSQLDBContext;

namespace ProductMicroservice.Repository
{
    public interface IProduct
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id,Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
