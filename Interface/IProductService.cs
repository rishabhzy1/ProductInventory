using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventory.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> Update(int id, Product product);

        Task<Product> Create(Product product);

        Task<bool> Delete(int id);
                                
        
    }
}
