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
    public class AvailableSupplyController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public AvailableSupplyController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/AvailableSupply
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblSupplyAvailable>>> GetTblSupplyAvailables()
        {
            return await _context.TblSupplyAvailables.ToListAsync();
        }

        // GET: api/AvailableSupply/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblSupplyAvailable>> GetTblSupplyAvailable(int id)
        {
            var tblSupplyAvailable = await _context.TblSupplyAvailables.FindAsync(id);

            if (tblSupplyAvailable == null)
            {
                return NotFound();
            }

            return tblSupplyAvailable;
        }

        // PUT: api/AvailableSupply/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSupplyAvailable(int id, TblSupplyAvailable tblSupplyAvailable)
        {
            if (id != tblSupplyAvailable.ASupplyId)
            {
                return BadRequest();
            }

            _context.Entry(tblSupplyAvailable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSupplyAvailableExists(id))
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

        // POST: api/AvailableSupply
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblSupplyAvailable>> PostTblSupplyAvailable(TblSupplyAvailable tblSupplyAvailable)
        {
            _context.TblSupplyAvailables.Add(tblSupplyAvailable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSupplyAvailable", new { id = tblSupplyAvailable.ASupplyId }, tblSupplyAvailable);
        }

        // DELETE: api/AvailableSupply/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSupplyAvailable(int id)
        {
            var tblSupplyAvailable = await _context.TblSupplyAvailables.FindAsync(id);
            if (tblSupplyAvailable == null)
            {
                return NotFound();
            }

            _context.TblSupplyAvailables.Remove(tblSupplyAvailable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblSupplyAvailableExists(int id)
        {
            return _context.TblSupplyAvailables.Any(e => e.ASupplyId == id);
        }
    }
}
