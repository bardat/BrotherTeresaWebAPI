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
    public class AvailableFoodController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public AvailableFoodController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/AvailableFood
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFoodAvailable>>> GetTblFoodAvailables()
        {
            return await _context.TblFoodAvailables.ToListAsync();
        }

        // GET: api/AvailableFood/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFoodAvailable>> GetTblFoodAvailable(int id)
        {
            var tblFoodAvailable = await _context.TblFoodAvailables.FindAsync(id);

            if (tblFoodAvailable == null)
            {
                return NotFound();
            }

            return tblFoodAvailable;
        }

        // PUT: api/AvailableFood/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFoodAvailable(int id, TblFoodAvailable tblFoodAvailable)
        {
            if (id != tblFoodAvailable.AFoodId)
            {
                return BadRequest();
            }

            _context.Entry(tblFoodAvailable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFoodAvailableExists(id))
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

        // POST: api/AvailableFood
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblFoodAvailable>> PostTblFoodAvailable(TblFoodAvailable tblFoodAvailable)
        {
            _context.TblFoodAvailables.Add(tblFoodAvailable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFoodAvailable", new { id = tblFoodAvailable.AFoodId }, tblFoodAvailable);
        }

        // DELETE: api/AvailableFood/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFoodAvailable(int id)
        {
            var tblFoodAvailable = await _context.TblFoodAvailables.FindAsync(id);
            if (tblFoodAvailable == null)
            {
                return NotFound();
            }

            _context.TblFoodAvailables.Remove(tblFoodAvailable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFoodAvailableExists(int id)
        {
            return _context.TblFoodAvailables.Any(e => e.AFoodId == id);
        }
    }
}
