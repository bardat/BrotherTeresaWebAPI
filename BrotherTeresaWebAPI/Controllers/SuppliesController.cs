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
    public class SuppliesController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public SuppliesController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/Supplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSupply>>> GetTblSupplies()
        {
            return await _context.TblSupplies.ToListAsync();
        }

        // GET: api/Supplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSupply>> GetTblSupply(int id)
        {
            var tblSupply = await _context.TblSupplies.FindAsync(id);

            if (tblSupply == null)
            {
                return NotFound();
            }

            return tblSupply;
        }

        // PUT: api/Supplies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSupply(int id, TblSupply tblSupply)
        {
            if (id != tblSupply.SupplyId)
            {
                return BadRequest();
            }

            _context.Entry(tblSupply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSupplyExists(id))
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

        // POST: api/Supplies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSupply>> PostTblSupply(TblSupply tblSupply)
        {
            _context.TblSupplies.Add(tblSupply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSupply", new { id = tblSupply.SupplyId }, tblSupply);
        }

        // DELETE: api/Supplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSupply(int id)
        {
            var tblSupply = await _context.TblSupplies.FindAsync(id);
            if (tblSupply == null)
            {
                return NotFound();
            }

            _context.TblSupplies.Remove(tblSupply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSupplyExists(int id)
        {
            return _context.TblSupplies.Any(e => e.SupplyId == id);
        }
    }
}
