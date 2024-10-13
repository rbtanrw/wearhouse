using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WearHouse.Data;
using WearHouse.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WearHouse.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public List<ProductCategory> Get()
        {
            var categoryList = _context.ProductCategories
                .Select(x => new ProductCategory
                {
                    Category = x.Category,
                    ProductID = x.ProductID,
                    UserID = x.UserID,
                });
            return categoryList.ToList();
        }

        // POST api/<CategoryController>
        [HttpPost("{UserID}, {Item}")]
        public async Task<ActionResult> PostAsync(string UserId, string Item)
        {
            if(_context.ProductCategories.Any(x => x.Category == Item))
            {
                return BadRequest("Category Already Exist");
            }

            var i = 0;
            foreach(ProductCategory p in _context.ProductCategories)
            {
                if(p.UserID == UserId)
                {
                    i++;
                }
            }

            var category = new ProductCategory
            {
                Category = Item,
                UserID = UserId,
                ProductID = string.Concat(UserId, "-PR", i.ToString("D2"))
            };

            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{ProductId}")]
        public async Task<ActionResult> PutAsync(string ProductId, [FromBody] string value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_context.ProductCategories.Any(x => x.ProductID == ProductId))
            {
                return NotFound("ProductID not found");
            }

            var category = await _context.ProductCategories.FirstOrDefaultAsync(x => x.ProductID == ProductId);
            if(category != null)
            {
                category.Category = value;
            }

            await _context.SaveChangesAsync();

            return Ok();

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{Item}")]
        public async Task<ActionResult> DeleteAsync(string Item)
        {
            var category = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Category == Item);

            if(category == null)
            {
                return NotFound("Category not found");
            }

            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
