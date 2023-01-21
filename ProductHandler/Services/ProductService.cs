using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductHandler.Data;
using ProductHandler.Models;
using ProductHandler.Services;
using X.PagedList;
using System.Drawing;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly ProductHandlerContext _context;

        public ProductService(ProductHandlerContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            if (products != null && products.Any())
            {
                return products;
            }

            return new List<ProductModel>();
        }

        public async Task<ProductModel> GetProduct(int? id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task SaveProduct(ProductModel productModel)
        {
            productModel.CreatedDate = DateTime.Now;

            _context.Add(productModel);
            await _context.SaveChangesAsync();

        }
        public async Task EditProduct(ProductModel productModel)
        {
            _context.Update(productModel);
            _context.Entry(productModel).Property(x => x.CreatedDate).IsModified = false;
            await _context.SaveChangesAsync();

        }
        public async Task DeleteProduct(int? id)
        {
            var product = await GetProduct(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
