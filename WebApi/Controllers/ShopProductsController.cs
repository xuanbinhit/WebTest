using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopProductsController : ControllerBase
    {
        private readonly DataTestContext _context;

        public ShopProductsController(DataTestContext context)
        {
            _context = context;
        }
        // GET: api/ShopProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetShopProduct(int id)
        {
            var td = from sp in _context.ShopProducts
                     join p in _context.Products on sp.ProductID equals p.ProductID
                     where sp.ShopID == id
                     orderby p.Price descending
                     select p;

            return await td.ToListAsync();
        }

        // GET: api/ShopProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopProduct>>> GetShopProducts()
        {
            
            return await _context.ShopProducts.ToListAsync();
        }

        
        // PUT: api/ShopProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopProduct(int id, ShopProduct shopProduct)
        {
            if (id != shopProduct.ShopProductID)
            {
                return BadRequest();
            }

            _context.Entry(shopProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShopProducts
        [HttpPost]
        public async Task<ActionResult<ShopProduct>> PostShopProduct(ShopProduct shopProduct)
        {
            var ProductLast = _context.ShopProducts.OrderByDescending(u => u.ShopProductID).FirstOrDefault();
            if (ProductLast != null)
            {
                shopProduct.ShopProductID = ProductLast.ShopProductID + 1;
            }
            _context.ShopProducts.Add(shopProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShopProductExists(shopProduct.ShopProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShopProduct", new { id = shopProduct.ShopProductID }, shopProduct);
        }

        // DELETE: api/ShopProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopProduct(int id)
        {
            var shopProduct = await _context.ShopProducts.FindAsync(id);
            if (shopProduct == null)
            {
                return NotFound();
            }

            _context.ShopProducts.Remove(shopProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopProductExists(int id)
        {
            return _context.ShopProducts.Any(e => e.ShopProductID == id);
        }
    }
}
