using EcommerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic;
using ProjectClasses;

namespace EcommerApi.Controllers
{
    [ApiController]
    [Route("Home")]
    public class ProductContoller:ControllerBase
    {
        private readonly ProjectDbContext context;
       public ProductContoller(ProjectDbContext context)
        {
            this.context = context;

        }
        public async Task<Product> GetProduct(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        [HttpGet("Products")]
        public async Task<ActionResult> GetAllProducts()
        {
            var Products = context.Products.ToListAsync();
            return Ok(Products);
        }
   
        [HttpGet("Products/{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product =await GetProduct(id);
            if (product!=null)
            {
                return Ok(product);
            }
            return BadRequest(new { message = "Product Does Not Exist" });
        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (product != null)
            {
                await context.Products.AddAsync(product);
                int row = await context.SaveChangesAsync();
                if (row > 0)
                {
                    return Ok(product);
                }
            }
            return BadRequest(new { message = "Null" });
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product product,int id)
        {
            var prevProduct = await GetProduct(id);
            if(prevProduct==null)
            {
                return BadRequest(new { message = "Product Does Not exst" });
            }
            prevProduct.ProductName = product.ProductName;
            prevProduct.Price = product.Price;
            prevProduct.Quantity = product.Quantity;
            prevProduct.Category = product.Category;
            prevProduct.ModifiedAt = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return Ok(prevProduct);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await context.Products.Where(p=>p.Id==id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
          int row= await  context.SaveChangesAsync();
            if(row>0)
            {
                Ok(new { message = "Product Deleted Successfully" });

            }
            return BadRequest(new { message = "Product Does not Exist" });
        }
        [HttpPost("AddCategory")]
        public async Task<ActionResult> AddCategory(Category category)
        {
           await context.Categories.AddAsync(category);
            
            int row =await context.SaveChangesAsync();
            if (row > 0)
            {
              return  Ok(new { category, Message = "Success" });
            }
            return BadRequest(new { message = "Something Goes Wrong" });

        }
        [HttpGet("GetCategory")]
        public async Task<ActionResult> GetAllCategory()
        {
            var categories =await context.Categories.ToListAsync();
            return Ok(categories);
        }
        
        
    }
    
}
