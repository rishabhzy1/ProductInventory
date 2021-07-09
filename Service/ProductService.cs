using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Interface;
using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventory.Service
{
    public class ProductService : IProductService
    {
        private readonly ProductInventoryContext _context;

        public ProductService(ProductInventoryContext context)
        {
            _context = context;      
        }
        public async Task<Product> Create(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> Update(int id, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
