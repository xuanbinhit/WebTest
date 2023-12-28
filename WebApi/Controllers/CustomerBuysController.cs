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
    public class CustomerBuysController : ControllerBase
    {
        private readonly DataTestContext _context;

        public CustomerBuysController(DataTestContext context)
        {
            _context = context;
        }

        // GET: api/CustomerBuys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCustomerBuys()
        {
            var td = from cb in _context.CustomerBuys
                     join c in _context.Customers on cb.CustomerID equals c.CustomerID
                     join sp in _context.ShopProducts on cb.ShopProductID equals sp.ShopProductID
                     join s in _context.Shops on sp.ShopID equals s.ShopID
                     join p in _context.Products on sp.ProductID equals p.ProductID
                     orderby c.Email ascending, s.Location descending, p.Price descending
                     select new
                     {
                         CustomerName = c.Name,
                         CustomerEmail = c.Email,
                         ShopName = s.Name,
                         ShopLocation = s.Location,
                         ProductName = p.Name,
                         ProductPrice = p.Price
                     };

            return await td.ToListAsync();
            // return await _context.CustomerBuys.ToListAsync();
        }
        // GET: api/CustomerBuys/Product
        [HttpGet("Product")]
        public async Task<ActionResult<IEnumerable<object>>> CustomerBuys_Product()
        {
            var td = from sp in _context.ShopProducts
                     join s in _context.Shops on sp.ShopID equals s.ShopID
                     join p in _context.Products on sp.ProductID equals p.ProductID
                     orderby s.Location descending, p.Price descending
                     select new
                     {
                         ShopName = s.Name,
                         ShopLocation = s.Location,
                         ProductName = p.Name,
                         ProductPrice = p.Price
                     };

            return await td.ToListAsync();
            // return await _context.CustomerBuys.ToListAsync();
        }

        // GET: api/CustomerBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBuy>> GetCustomerBuy(int id)
        {
            var customerBuy = await _context.CustomerBuys.FindAsync(id);

            if (customerBuy == null)
            {
                return NotFound();
            }

            return customerBuy;
        }

        // PUT: api/CustomerBuys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerBuy(int id, CustomerBuy customerBuy)
        {
            if (id != customerBuy.CustomerBuyID)
            {
                return BadRequest();
            }

            _context.Entry(customerBuy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerBuyExists(id))
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

        // POST: api/CustomerBuys
        [HttpPost]
        public async Task<ActionResult<CustomerBuy>> PostCustomerBuy(CustomerBuy customerBuy)
        {
            var ShoppingLast = _context.CustomerBuys.OrderByDescending(u => u.CustomerBuyID).FirstOrDefault();
            if (ShoppingLast != null)
            {
                customerBuy.CustomerBuyID = ShoppingLast.CustomerBuyID + 1;
            }
            _context.CustomerBuys.Add(customerBuy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerBuyExists(customerBuy.CustomerBuyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerBuy", new { id = customerBuy.CustomerBuyID }, customerBuy);
        }

        // DELETE: api/CustomerBuys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerBuy(int id)
        {
            var customerBuy = await _context.CustomerBuys.FindAsync(id);
            if (customerBuy == null)
            {
                return NotFound();
            }

            _context.CustomerBuys.Remove(customerBuy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerBuyExists(int id)
        {
            return _context.CustomerBuys.Any(e => e.CustomerBuyID == id);
        }
    }
}
