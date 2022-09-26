using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly apipracticeContext db;

        public ProductsController(apipracticeContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<Product>>> getProducts()
        {
            return Ok(await db.Products.ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> getProductById(int id)
        {
            return Ok(await db.Products.FindAsync(id));
        }

        //[HttpGet]
        //public async Task<ActionResult<IQueryable<Product>>> getProductByPriceAndManufacturer(float price, string manufacturer)
        //{
        //    return Ok(await db.Products.Where(x => x.Price == price && x.Manufacturedby == manufacturer).SingleOrDefaultAsync());
        //}

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product prd)
        {
            if(prd == null)
            {
                return BadRequest();
            } 
            
            if(ModelState.IsValid)
            {
                db.Products.Add(prd);
                await db.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product prd)
        {
            if (prd == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                db.Products.Update(prd);
                await db.SaveChangesAsync();
            }

            return Ok(prd);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product prd = db.Products.Find(id);
            db.Products.Remove(prd);
            await db.SaveChangesAsync();
            return Ok(prd);
        }
    }
}
