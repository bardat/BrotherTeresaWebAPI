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
    public class PersonsController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public PersonsController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPerson>>> GetTblPeople()
        {
            return await _context.TblPeople.ToListAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPerson>> GetTblPerson(int id)
        {
            var tblPerson = await _context.TblPeople.FindAsync(id);

            if (tblPerson == null)
            {
                return NotFound();
            }

            return tblPerson;
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPerson(int id, TblPerson tblPerson)
        {
            if (id != tblPerson.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(tblPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPersonExists(id))
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

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPerson>> PostTblPerson(TblPerson tblPerson)
        {
            _context.TblPeople.Add(tblPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPerson", new { id = tblPerson.PersonId }, tblPerson);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPerson(int id)
        {
            var tblPerson = await _context.TblPeople.FindAsync(id);
            if (tblPerson == null)
            {
                return NotFound();
            }

            _context.TblPeople.Remove(tblPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblPersonExists(int id)
        {
            return _context.TblPeople.Any(e => e.PersonId == id);
        }
    }
}
