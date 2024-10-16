using shop_app.Models;

namespace shop_app.Services
{
    public interface IServiceProduct
    {
        Task<Product?> CreateAsync(Product? product);
        Task<IEnumerable<Product>> ReadAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> UpdateAsync(int id, Product? product);
        Task<bool> DeleteAsync(int id);
    }
    public class ServiceProduct : IServiceProduct
    {
        private readonly ProductContext _productContext;
        public ServiceProduct(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public Task<Product?> CreateAsync(Product? product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateAsync(int id, Product? product)
        {
            throw new NotImplementedException();
        }
    }
}
