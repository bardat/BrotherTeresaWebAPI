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
    public class RequestsController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public RequestsController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRequest>>> GetTblRequests()
        {
            return await _context.TblRequests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRequest>> GetTblRequest(int id)
        {
            var tblRequest = await _context.TblRequests.FindAsync(id);

            if (tblRequest == null)
            {
                return NotFound();
            }

            return tblRequest;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRequest(int id, TblRequest tblRequest)
        {
            if (id != tblRequest.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(tblRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRequestExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblRequest>> PostTblRequest(TblRequest tblRequest)
        {
            _context.TblRequests.Add(tblRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblRequest", new { id = tblRequest.RequestId }, tblRequest);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRequest(int id)
        {
            var tblRequest = await _context.TblRequests.FindAsync(id);
            if (tblRequest == null)
            {
                return NotFound();
            }

            _context.TblRequests.Remove(tblRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblRequestExists(int id)
        {
            return _context.TblRequests.Any(e => e.RequestId == id);
        }
    }
}
