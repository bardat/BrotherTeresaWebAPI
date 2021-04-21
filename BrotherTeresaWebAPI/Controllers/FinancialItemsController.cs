using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrotherTeresaWebAPI.Models;

namespace BrotherTeresaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialItemsController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public FinancialItemsController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/FinancialItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFinancialItem>>> GetTblFinancialItems()
        {
            return await _context.TblFinancialItems.ToListAsync();
        }

        // GET: api/FinancialItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFinancialItem>> GetTblFinancialItem(int id)
        {
            var tblFinancialItem = await _context.TblFinancialItems.FindAsync(id);

            if (tblFinancialItem == null)
            {
                return NotFound();
            }

            return tblFinancialItem;
        }

        // PUT: api/FinancialItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFinancialItem(int id, TblFinancialItem tblFinancialItem)
        {
            if (id != tblFinancialItem.FinancialItemId)
            {
                return BadRequest();
            }

            _context.Entry(tblFinancialItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFinancialItemExists(id))
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

        // POST: api/FinancialItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblFinancialItem>> PostTblFinancialItem(TblFinancialItem tblFinancialItem)
        {
            _context.TblFinancialItems.Add(tblFinancialItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFinancialItem", new { id = tblFinancialItem.FinancialItemId }, tblFinancialItem);
        }

        // DELETE: api/FinancialItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFinancialItem(int id)
        {
            var tblFinancialItem = await _context.TblFinancialItems.FindAsync(id);
            if (tblFinancialItem == null)
            {
                return NotFound();
            }

            _context.TblFinancialItems.Remove(tblFinancialItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFinancialItemExists(int id)
        {
            return _context.TblFinancialItems.Any(e => e.FinancialItemId == id);
        }
    }
}
