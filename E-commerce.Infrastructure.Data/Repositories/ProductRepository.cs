using E_commerceWebsite.AggregateModels.IRepositories;
using E_commerceWebsite.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> GetProductById(int ProductId)
        {
            return await _dbContext.products
                 .Include(p => p.ProductType)
                .Include(P => P.ProductBrand)
                .FirstOrDefaultAsync(p=>p.Id==ProductId);

        }

        public async Task<Product> GetProductByName(string productName)
        {
            return await _dbContext.products
                 .Include(p => p.ProductType)
                .Include(P => P.ProductBrand)
                .FirstOrDefaultAsync(p => p.Name == productName);

        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _dbContext.products
                .Include(p=>p.ProductType)
                .Include(P=>P.ProductBrand)
                .ToListAsync();
        }


        public async Task AddProduct(Product product)
        {
            _dbContext.products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var productToDelete = await _dbContext.products.FindAsync(productId);

            if (productToDelete != null)
            {
                _dbContext.products.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateProduct(Product updatedProduct)
        {
            var existingProduct = await _dbContext.products.FindAsync(updatedProduct.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.PictureUrl = updatedProduct.PictureUrl;
                existingProduct.ProductTypeId = updatedProduct.ProductTypeId;
                existingProduct.ProductBrandId = updatedProduct.ProductBrandId;

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
