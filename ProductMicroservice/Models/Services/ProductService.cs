using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models.Data.MicroserviceSQLDBContext;
using ProductMicroservice.Repository;

namespace ProductMicroservice.Models.Services
{
    public class ProductService : IProduct
    {
        private readonly MicroserviceSqldbContext _Context;
        public ProductService(MicroserviceSqldbContext context)
        {
            _Context = context;
        }

        public async Task<bool> AddProductAsync(Product product)
        {
           await _Context.AddAsync(product);
           await _Context.SaveChangesAsync();
           return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            Product product = await _Context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            _Context.Products.Remove(product);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _Context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _Context.Products.ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            Product getProduct = await _Context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            getProduct.ProductName = product.ProductName;
            getProduct.ProductPrice = product.ProductPrice;
            getProduct.ProductDesc = product.ProductDesc;
            _Context.Products.Update(getProduct);
            await _Context.SaveChangesAsync();
            return true;

        }
    }
}
