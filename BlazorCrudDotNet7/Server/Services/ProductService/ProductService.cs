using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if (dbProduct == null)
            {
                return false;
            }

            _context.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product?> GetProductById(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            return dbProduct;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> UpdateProduct(int productId, Product product)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if (dbProduct != null)
            {
                dbProduct.ImageUrl = product.ImageUrl;
                dbProduct.Title = product.Title;
                dbProduct.Description = product.Description;
                dbProduct.Quantity = product.Quantity;
                dbProduct.CategoryId = product.CategoryId;
                dbProduct.Price = product.Price;

                await _context.SaveChangesAsync();
            }

            return dbProduct;
        }
    }
}
