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
    public class LogsController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public LogsController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/Logs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLog>>> GetTblLogs()
        {
            return await _context.TblLogs.ToListAsync();
        }

        // GET: api/Logs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblLog>> GetTblLog(int id)
        {
            var tblLog = await _context.TblLogs.FindAsync(id);

            if (tblLog == null)
            {
                return NotFound();
            }

            return tblLog;
        }

        // PUT: api/Logs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLog(int id, TblLog tblLog)
        {
            if (id != tblLog.LogId)
            {
                return BadRequest();
            }

            _context.Entry(tblLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLogExists(id))
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

        // POST: api/Logs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLog>> PostTblLog(TblLog tblLog)
        {
            _context.TblLogs.Add(tblLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblLog", new { id = tblLog.LogId }, tblLog);
        }

        // DELETE: api/Logs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLog(int id)
        {
            var tblLog = await _context.TblLogs.FindAsync(id);
            if (tblLog == null)
            {
                return NotFound();
            }

            _context.TblLogs.Remove(tblLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblLogExists(int id)
        {
            return _context.TblLogs.Any(e => e.LogId == id);
        }
    }
}
