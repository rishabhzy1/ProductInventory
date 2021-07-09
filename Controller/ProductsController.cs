using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Data;
using ProductInventory.Interface;
using ProductInventory.Models;

namespace ProductInventory.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            
              return Ok(await _productService.GetProducts());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try { 
                
                return Ok(await _productService.Update(id, product));
            }
            catch {

                return BadRequest();
            }
           
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _productService.Create(product);
            

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var result = await _productService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

           
        } 

        
    }
}
