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
    public class LocationsController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public LocationsController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLocation>>> GetTblLocations()
        {
            return await _context.TblLocations.ToListAsync();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLocation>> GetTblLocation(int id)
        {
            var tblLocation = await _context.TblLocations.FindAsync(id);

            if (tblLocation == null)
            {
                return NotFound();
            }

            return tblLocation;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLocation(int id, TblLocation tblLocation)
        {
            if (id != tblLocation.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(tblLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLocation>> PostTblLocation(TblLocation tblLocation)
        {
            _context.TblLocations.Add(tblLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLocation", new { id = tblLocation.LocationId }, tblLocation);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLocation(int id)
        {
            var tblLocation = await _context.TblLocations.FindAsync(id);
            if (tblLocation == null)
            {
                return NotFound();
            }

            _context.TblLocations.Remove(tblLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLocationExists(int id)
        {
            return _context.TblLocations.Any(e => e.LocationId == id);
        }
    }
}
