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
    public class FoodsController : ControllerBase
    {
        private readonly BrotherTeresaDBContext _context;

        public FoodsController(BrotherTeresaDBContext context)
        {
            _context = context;
        }

        // GET: api/Foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblFood>>> GetTblFoods()
        {
            return await _context.TblFoods.ToListAsync();
        }

        // GET: api/Foods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblFood>> GetTblFood(int id)
        {
            var tblFood = await _context.TblFoods.FindAsync(id);

            if (tblFood == null)
            {
                return NotFound();
            }

            return tblFood;
        }

        // PUT: api/Foods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblFood(int id, TblFood tblFood)
        {
            if (id != tblFood.FoodId)
            {
                return BadRequest();
            }

            _context.Entry(tblFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblFoodExists(id))
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

        // POST: api/Foods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblFood>> PostTblFood(TblFood tblFood)
        {
            _context.TblFoods.Add(tblFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblFood", new { id = tblFood.FoodId }, tblFood);
        }

        // DELETE: api/Foods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblFood(int id)
        {
            var tblFood = await _context.TblFoods.FindAsync(id);
            if (tblFood == null)
            {
                return NotFound();
            }

            _context.TblFoods.Remove(tblFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblFoodExists(int id)
        {
            return _context.TblFoods.Any(e => e.FoodId == id);
        }
    }
}
